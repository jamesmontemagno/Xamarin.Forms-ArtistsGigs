using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistGigs.Models.Artist
{
  public class Artist
  {

    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    [JsonProperty(PropertyName = "playcount")]
    public string PlayCount { get; set; }

    [JsonProperty(PropertyName = "listeners")]
    public string ListenerCount { get; set; }

    [JsonProperty(PropertyName = "mbid")]
    public string mbid { get; set; }

    [JsonProperty(PropertyName = "url")]
    public string Url { get; set; }

    [JsonProperty(PropertyName = "streamable")]
    public string Streamable { get; set; }

    [JsonProperty(PropertyName = "image")]
    public List<Image> Images { get; set; }
    
    [JsonIgnore]
    public string MediumImage
    {
      get
      {
        return GetImage("medium");
      }
    }


    [JsonIgnore]
    public string LargeImage
    {
      get
      {
        return GetImage("large");
      }
    }

    private string GetImage(string size)
    {
      if (Images == null)
        return string.Empty;

      var image = Images.FirstOrDefault(i => i.Size == "medium");
      if (image == null)
        return string.Empty;

      return image.Url;
    }
  }
}
