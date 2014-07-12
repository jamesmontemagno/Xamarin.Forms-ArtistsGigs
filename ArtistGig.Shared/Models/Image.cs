using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistGigs.Models
{
  public class Image
  {
      [JsonProperty(PropertyName="#text")]
      public string Url { get; set; }

      [JsonProperty(PropertyName = "size")]
      public string Size { get; set; }
  }
}
