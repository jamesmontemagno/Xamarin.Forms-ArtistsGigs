using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistGigs.Models.Events
{
  public class Venue
  {
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }


    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    [JsonProperty(PropertyName = "location")]
    public Location Location { get; set; }

    [JsonProperty(PropertyName = "url")]
    public string Url { get; set; }


    [JsonProperty(PropertyName = "website")]
    public string website { get; set; }


    [JsonProperty(PropertyName = "phonenumber")]
    public string PhoneNumber { get; set; }

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
