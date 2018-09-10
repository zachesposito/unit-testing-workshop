using Newtonsoft.Json;

namespace UnitTestingWorkshop.Demo.Services.Movies.Models
{
    public class Language
    {
        [JsonProperty("iso_639_1")]
        public string ISOAbbreviation { get; set; }
        public string Name { get; set; }
    }
}