using ArtistGigs.Models.Artist;
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
  public class ArtistsViewModel : BaseViewModel
  {

    private const string TopArtistsUrl = "http://ws.audioscrobbler.com/2.0/?method=chart.gettopartists&api_key=1dd9cea05e99f98a60d9afd585839bb0&format=json";
    public ArtistsViewModel()
    {
      this.Title = "Artists";
      Artists = new ObservableCollection<Artist>();
    }

    
    /// <summary>
    /// gets or sets the feed items
    /// </summary>
    public ObservableCollection<Artist> Artists
    {
      get;
      private set;
    }


    private Command loadCommand;
    /// <summary>
    /// Command to load/refresh artitists
    /// </summary>
    public Command LoadCommand
    {
      get { return loadCommand ?? (loadCommand = new Command(async () => await ExecuteLoadCommand())); }
    }

    private async Task ExecuteLoadCommand()
    {
      if (IsBusy)
        return;

      IsBusy = true;

      try
      {
        var httpClient = new HttpClient();
        var response = await httpClient.GetStringAsync(TopArtistsUrl);

        Artists.Clear();
        var artists = JsonConvert.DeserializeObject<ArtistRootObject>(response);
        foreach (var artist in artists.Result.ArtistList)
        {
          Artists.Add(artist);
        }
      }
      catch (Exception ex)
      {
        var page = new ContentPage();
        page.DisplayAlert("Error", "Unable to load artists.", "OK");
      }

      IsBusy = false;
    }

  }
}
