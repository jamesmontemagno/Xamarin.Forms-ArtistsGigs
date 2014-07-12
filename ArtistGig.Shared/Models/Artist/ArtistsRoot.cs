using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistGigs.Models.Artist
{
  public class Artists
  {
    [JsonProperty(PropertyName = "artist")]
    public List<Artist> ArtistList { get; set; }
  }

  public class ArtistRootObject
  {
    [JsonProperty(PropertyName = "artists")]
    public Artists Result { get; set; }
  }
}
