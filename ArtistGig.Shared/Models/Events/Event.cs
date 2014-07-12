using ArtistGigs.Models.Artist;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistGigs.Models.Events
{
  public class Event
  {
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    [JsonProperty(PropertyName = "title")]
    public string Title { get; set; }


    [JsonProperty(PropertyName = "venue")]
    public Venue Venue { get; set; }

    [JsonProperty(PropertyName = "startDate")]
    public string StartDate { get; set; }

    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    [JsonProperty(PropertyName = "image")]
    public List<Image> Images { get; set; }

    [JsonProperty(PropertyName = "attendance")]
    public string Attendance { get; set; }

    [JsonProperty(PropertyName = "reviews")]
    public string Reviews { get; set; }

    [JsonProperty(PropertyName = "url")]
    public string Url { get; set; }

    [JsonProperty(PropertyName = "website")]
    public string Website { get; set; }

    [JsonProperty(PropertyName = "tickets")]
    public string Tickets { get; set; }

    [JsonProperty(PropertyName = "endDate")]
    public string EndDate { get; set; }

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
