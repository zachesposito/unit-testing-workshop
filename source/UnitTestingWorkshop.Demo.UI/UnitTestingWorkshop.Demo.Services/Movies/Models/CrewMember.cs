using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestingWorkshop.Demo.Services.Movies.Models
{
    public class CrewMember
    {
        [JsonProperty("credit_id")]
        public string CreditID { get; set; }
        public string Department { get; set; }
        public Gender Gender { get; set; }
        public int ID { get; set; }
        public string Job { get; set; }
        public string Name { get; set; }
    }
}
