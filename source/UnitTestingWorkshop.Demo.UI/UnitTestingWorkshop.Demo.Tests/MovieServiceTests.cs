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

            Assert.Equal(5, movies.Count());
        }

        [Fact]
        public void ShouldGetTopPopularMovies()
        {
            var mockMovieDataService = new Mock<IMovieDataService>();
            mockMovieDataService.Setup(s => s.LoadMovies())
                .Returns(CreateTestMovieCollection());

            var movieService = new MovieService(mockMovieDataService.Object);

            var movies = movieService.GetTopPopularMovies(3);

            Assert.Equal(3, movies.Count());
            Assert.True(movies.First().Popularity == movies.Max(m => m.Popularity)); //The movie sorted first should have the highest popularity 
        }

        [Fact]
        public void ShouldGetDistinctGenres()
        {
            var mockMovieDataService = new Mock<IMovieDataService>();
            mockMovieDataService.Setup(s => s.LoadMovies())
                .Returns(CreateTestMovieCollection());

            var movieService = new MovieService(mockMovieDataService.Object);

            var distinctGenres = movieService.GetDistinctGenres();

            Assert.Equal(4, distinctGenres.Count());
            Assert.True(distinctGenres.Distinct().Count() == distinctGenres.Count()); //Check whether result is really distinct
        }

        private IEnumerable<Movie> CreateTestMovieCollection()
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
