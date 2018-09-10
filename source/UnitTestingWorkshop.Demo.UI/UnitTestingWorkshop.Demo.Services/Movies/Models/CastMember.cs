using Newtonsoft.Json;

namespace UnitTestingWorkshop.Demo.Services.Movies.Models
{
    public class CastMember
    {
        [JsonProperty("cast_id")]
        public int CastID { get; set; }
        public string Character { get; set; }
        [JsonProperty("credit_id")]
        public string CreditID { get; set; }
        public Gender Gender { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
    }
}