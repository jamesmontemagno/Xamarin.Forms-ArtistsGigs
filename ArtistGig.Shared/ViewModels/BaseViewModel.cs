using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistGigs.ViewModels
{
  public class BaseViewModel : INotifyPropertyChanged
  {
    public string Title { get; set; }
    public bool IsInitialized { get; set; }

    private bool isBusy;
    /// <summary>
    /// Gets or sets if VM is busy working
    /// </summary>
    public bool IsBusy
    {
      get { return isBusy; }
      set { isBusy = value; OnPropertyChanged("IsBusy"); }
    }

    //INotifyPropertyChanged Implementation
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged == null)
        return;

      PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
