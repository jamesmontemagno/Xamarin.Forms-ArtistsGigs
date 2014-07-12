using ArtistGig.Shared.Views;
using ArtistGigs.Models.Artist;
using ArtistGigs.Models.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArtistGigs.ViewModels
{
  public class EventsViewModel : BaseViewModel
  {
    private const string EventsUrl = "http://ws.audioscrobbler.com/2.0/?method=artist.getevents&mbid={0}&api_key=1dd9cea05e99f98a60d9afd585839bb0&format=json";
    private string mbid = string.Empty;
    private Page page;
    public Artist Artist { get; set; }
    public EventsViewModel(Artist artist, Page page)
    {
      this.Artist = artist;
      this.page = page;
      this.Title = artist.Name;
      this.mbid = artist.mbid;
      Events = new ObservableCollection<Event>();
    }


    /// <summary>
    /// gets or sets the events
    /// </summary>
    public ObservableCollection<Event> Events
    {
      get;
      private set;
    }

    private Event selectedEvent = null;
    public Event SelectedEvent
    {
      get { return selectedEvent; }
      set
      {
        if (value == null)
          return;
        
        selectedEvent = value;

        page.Navigation.PushAsync(new BuyTicketPage(selectedEvent.Url, selectedEvent.Title));

        selectedEvent = null;
        OnPropertyChanged("SelectedEvent");
      }
    }



    private Command loadCommand;
    /// <summary>
    /// Command to load/refresh events
    /// </summary>
    public Command LoadCommand
    {
      get { return loadCommand ?? (loadCommand = new Command(() => ExecuteLoadCommand())); }
    }

    private async Task ExecuteLoadCommand()
    {
      if (IsBusy)
        return;

      IsBusy = true;
      bool noShows = false;
      try
      {
        var httpClient = new HttpClient();
        var url = string.Format(EventsUrl, mbid);
        var response = await httpClient.GetStringAsync(url);

        Events.Clear();
        var events = JsonConvert.DeserializeObject<EventsRootObject>(response);
        foreach (var event1 in events.Result.EventList)
        {
          Events.Add(event1);
        }
      }
      catch (Exception ex)
      {
        noShows = true;
        
      }

      IsBusy = false;

      if(noShows)
      {
        await page.DisplayAlert("No Shows", "No upcoming shows for: " + Title, "OK");
        page.Navigation.PopAsync();
      }
    }
  }
}
