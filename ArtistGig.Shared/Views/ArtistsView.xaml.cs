using ArtistGigs.Models.Artist;
using ArtistGigs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistGig.Shared.Views
{
	public partial class ArtistsView
	{
    ArtistsViewModel viewModel;
		public ArtistsView ()
		{
			InitializeComponent ();
      this.BindingContext = viewModel = new ArtistsViewModel();

      this.List.ItemSelected += (sender, args) =>
        {

          if (List.SelectedItem == null)
            return;

          Navigation.PushAsync(new EventsView(List.SelectedItem as Artist));

          List.SelectedItem = null;
        };

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
