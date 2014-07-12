using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistGigs.Models.Events
{
  public class Events
  {
    [JsonProperty(PropertyName = "event")]
    public List<Event> EventList { get; set; }
  }

  public class EventsRootObject
  {
    [JsonProperty(PropertyName = "events")]
    public Events Result { get; set; }
  }
}
