using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestingWorkshop.Demo.Services.Movies.Models.DTOs
{
    public class Credits
    {
        public IEnumerable<CastMember> Cast { get; set; }
        public IEnumerable<CrewMember> Crew { get; set; }
        public int ID { get; set; }
    }
}
