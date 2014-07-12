using ArtistGigs.Models.Artist;
using ArtistGigs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistGig.Shared.Views
{
	public partial class EventsView
	{
    EventsViewModel viewModel;
    public EventsView(Artist artist)
    {
      InitializeComponent();
      this.BindingContext = viewModel = new EventsViewModel(artist, this);
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();
      if (viewModel.IsInitialized)
        return;

      viewModel.IsInitialized = true;
      viewModel.LoadCommand.Execute(null);
    }
	}
}
