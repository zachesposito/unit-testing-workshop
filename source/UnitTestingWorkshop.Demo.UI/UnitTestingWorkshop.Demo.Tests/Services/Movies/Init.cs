using System;
using System.Collections.Generic;
using UnitTestingWorkshop.Demo.Services.Movies.Models;

namespace UnitTestingWorkshop.Demo.Tests.Services.Movies
{
    public partial class MovieServiceTests
    {
        private static IEnumerable<Movie> CreateTestMovieCollection()
        {
            return new Movie[]
            {
                new Movie { Title = "Test Movie 1", Popularity = 1.0f, Genres = new Genre[]{ new Genre { ID = 1, Name = "Western" } } },
                new Movie { Title = "Test Movie 2", Popularity = 2.0f, Genres = new Genre[]{ new Genre { ID = 2, Name = "Sci-Fi" } } },
                new Movie { Title = "Test Movie 3", Popularity = 3.0f, Genres = new Genre[]{ new Genre { ID = 3, Name = "Romance" } } } ,
                new Movie { Title = "Test Movie 4", Popularity = 4.0f, Genres = new Genre[] { new Genre { ID = 2, Name = "Sci-Fi" } } } ,
                new Movie { Title = "Test Movie 5", Popularity = 5.0f, Genres = new Genre[]{ new Genre { ID = 4, Name = "Action" } } } 
            };
        }
    }
}