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

        public MovieService(MovieDataService movieDataService)
        {
            Movies = movieDataService.LoadMovies();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return Movies;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return Movies.SelectMany(m => m.Genres).Distinct();
        }
    }
}
