using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistGigs.Models.Events
{
  public class Location
  {
    [JsonProperty(PropertyName = "city")]
    public string City { get; set; }


    [JsonProperty(PropertyName = "country")]
    public string Country { get; set; }

    [JsonProperty(PropertyName = "street")]
    public string Street { get; set; }


    [JsonProperty(PropertyName = "postalcode")]
    public string PostalCode { get; set; }

    [JsonIgnore]
    public string Display
    {
      get { return this.ToString(); }
    }

    public override string ToString()
    {
      return City + ", " + Country;
    }
  }
}
