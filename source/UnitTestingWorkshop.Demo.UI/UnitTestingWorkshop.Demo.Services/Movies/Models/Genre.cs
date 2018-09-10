using System;
using System.Collections.Generic;

namespace UnitTestingWorkshop.Demo.Services.Movies.Models
{
    public class Genre : IEquatable<Genre>
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Genre);
        }

        public bool Equals(Genre other)
        {
            return other != null &&
                   ID == other.ID &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Name);
        }

        public static bool operator ==(Genre genre1, Genre genre2)
        {
            return EqualityComparer<Genre>.Default.Equals(genre1, genre2);
        }

        public static bool operator !=(Genre genre1, Genre genre2)
        {
            return !(genre1 == genre2);
        }
    }
}