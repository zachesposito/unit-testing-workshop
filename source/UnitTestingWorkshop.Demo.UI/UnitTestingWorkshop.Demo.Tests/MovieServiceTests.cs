using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestingWorkshop.Demo.Services.Movies;
using UnitTestingWorkshop.Demo.Services.Movies.Models;
using Xunit;

namespace UnitTestingWorkshop.Demo.Tests
{
    public class MovieServiceTests
    {
        [Fact]
        public void ShouldGetMovies()
        {
            var mockMovieDataService = new Mock<IMovieDataService>();
            mockMovieDataService.Setup(s => s.LoadMovies())
                .Returns(CreateTestMovieCollection());

            var movieService = new MovieService(mockMovieDataService.Object);

            var movies = movieService.GetMovies();

            Assert.Equal(3, movies.Count());
        }

        private IEnumerable<Movie> CreateTestMovieCollection()
        {
            return new Movie[]
            {
                new Movie { Title = "Test Movie 1" },
                new Movie { Title = "Test Movie 2" },
                new Movie { Title = "Test Movie 3" }
            };
        }
    }
}
