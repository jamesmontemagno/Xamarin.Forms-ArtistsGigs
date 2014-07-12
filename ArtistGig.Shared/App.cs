using ArtistGig.Shared.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ArtistGigs
{
  public class App
  {
    public static Page GetMainPage()
    {
      return new NavigationPage(new ArtistsView());
    }
  }
}
