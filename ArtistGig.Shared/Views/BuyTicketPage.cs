using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ArtistGig.Shared.Views
{
    public class BuyTicketPage : ContentPage
    {
      public BuyTicketPage(string url, string title)
      {
        Title = title;
        Content = new WebView
        {
          Source = new UrlWebViewSource { Url = url }
        };
      }
    }
}
