using System;
using Xunit;
using UnitTestingWorkshop.Demo.Services.Movies;
using Moq;
using UnitTestingWorkshop.Demo.Services.Movies.Models;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestingWorkshop.Demo.Tests
{
    public class MovieServiceTests
    {
        

        [Fact]
        public void ShouldGetMovies()
        {
            var movieserice = new MovieService(this.SetupMock());
            var movies = movieserice.GetMovies();
            Assert.Equal(5, movies.Count());
            Assert.Equal("Something", movies.First().Title);
        }

        [Fact]
        public void ShouldGetTopMoviesReturnNum()
        {
            int count = 3;
            var movieserice = new MovieService(this.SetupMock());
            var movies = movieserice.GetTopPopularMovies(count);
            Assert.Equal(count, movies.Count());
        }

        [Fact]
        public void ShouldGetTopMoviesReturnInOrder()
        {
            int count = 3;
            var movieserice = new MovieService(this.SetupMock());
            var movies = movieserice.GetTopPopularMovies(count);

            var test = CreateTestMovies().OrderByDescending(x => x.Popularity).Take(count);
            for (int i=0; i< count; i++)
                Assert.Equal(test.ElementAt(i).Popularity, movies.ElementAt(i).Popularity);
        }

        [Fact]
        public void ShouldSearchTagReturnMovies()
        {
            string badTag = "NOTIN";
            string newTag = "Awesome";

            var movieserice = new MovieService(this.SetupMock());
            var movies = movieserice.SearchTag(badTag);
            Assert.Empty(movies);

            movies = movieserice.SearchTag(newTag);
            Assert.NotEmpty(movies);

        }

        [Fact]
        public void ShouldSearchTitleReturnMovies()
        {
            string badTag = "NOTIN";
            string newTag = "Something";

            var movieserice = new MovieService(this.SetupMock());
            var movies = movieserice.SearchTag(badTag);
            Assert.Empty(movies);

            movies = movieserice.SearchTag(newTag);
            Assert.NotEmpty(movies);

        }

        private IMovieDataService SetupMock()
        {
            var mockDataService = new Mock<IMovieDataService>();
            mockDataService.Setup(s => s.LoadMovies())
                .Returns(CreateTestMovies());
            return mockDataService.Object;
        }

        private IEnumerable<Movie> CreateTestMovies()
        {
            return new Movie[]
            {
                new Movie
                {
                    Title = "Something", Popularity=99, Tagline="Awesome"
                },
                new Movie
                {
                    Title = "Rotten Tomato", Popularity=1, Tagline="Awesome 1"
                },
                 new Movie
                {
                    Title = "Something def", Popularity=55, Tagline="Awesome 2"
                },
                 new Movie
                {
                    Title = "#1 Movie", Popularity=99999, Tagline="Awesome 3"
                },
                new Movie
                {
                    Title = "Decent", Popularity=9999, Tagline="Awesome 4"
                }

            };
        }
    }
}
