using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTestingWorkshop.Demo.Services.Movies.Models;

namespace UnitTestingWorkshop.Demo.Services.Movies
{
    /// <summary>
    /// Analyzes movie data
    /// </summary>
    public class MovieService
    {
        private IEnumerable<Movie> Movies { get; set; }

        public MovieService(IMovieDataService movieDataService)
        {
            Movies = movieDataService.LoadMovies();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return Movies;
        }

        public IEnumerable<Movie> GetTopPopularMovies(int numberToShow)
        {
            return Movies.OrderByDescending(m => m.Popularity).Take(5);
        }
    }
}
