using Newtonsoft.Json;

namespace UnitTestingWorkshop.Demo.Services.Movies.Models
{
    public class Country
    {
        [JsonProperty("iso_3166_1")]
        public string ISOAbbreviation { get; set; }
        public string Name { get; set; }
    }
}