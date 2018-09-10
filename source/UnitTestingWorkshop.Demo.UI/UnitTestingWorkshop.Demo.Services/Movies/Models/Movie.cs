using CsvHelper.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestingWorkshop.Demo.Services.Movies.Models
{
    public class Movie
    {

        public bool Adult { get; set; }
        public int Budget { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public int ID { get; set; }
        public string IMDB_ID { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public float Popularity { get; set; }
        public IEnumerable<ProductionCompany> ProductionCompanies { get; set; }
        public IEnumerable<Country> ProductionCountries { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public long Revenue { get; set; }
        public float? Runtime { get; set; }
        public IEnumerable<Language> SpokenLanguages { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public float VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public IEnumerable<CastMember> Cast { get; set; }
        public IEnumerable<CrewMember> Crew { get; set; }

        public string GetDescription()
        {
            var descriptionLines = new List<string> {
                $"Title: {Title}",
                $"Tagline: {Tagline}",
                $"Release date: {(ReleaseDate.HasValue ? ReleaseDate.Value.ToShortDateString() : "None" )}",
                $"Genres: {string.Join(", ", Genres.Select(g => g.Name))}",
                $"Production Companies: {string.Join(", ", ProductionCompanies.Select(g => g.Name))}",
                $"Languages: {string.Join(", ", SpokenLanguages.Select(g => g.Name))}",
                $"Budget: {string.Format("{0:C}", Budget)}",
                $"Revenue: {string.Format("{0:C}", Revenue)}",
                $"Rating: {VoteAverage.ToString()}/10",
                $"Votes: {VoteCount.ToString()}",
                $"Popularity: {Popularity.ToString()}"
            };
            return string.Join(Environment.NewLine, descriptionLines);
        }
    }

    public sealed class MovieCSVMap : ClassMap<Movie>
    {
        public MovieCSVMap()
        {
            AutoMap();
            Map(m => m.Genres).ConvertUsing(r => JsonConvert.DeserializeObject<IEnumerable<Genre>>(SanitizeJson(r.GetField("genres"))));
            Map(m => m.ProductionCompanies).ConvertUsing(r => JsonConvert.DeserializeObject<IEnumerable<ProductionCompany>>(SanitizeJson(r.GetField("production_companies"))));
            Map(m => m.ProductionCountries).ConvertUsing(r => JsonConvert.DeserializeObject<IEnumerable<Country>>(SanitizeJson(r.GetField("production_countries"))));
            Map(m => m.SpokenLanguages).ConvertUsing(r => JsonConvert.DeserializeObject<IEnumerable<Language>>(SanitizeJson(r.GetField("spoken_languages"))));
            Map(m => m.ReleaseDate).ConvertUsing(r => ParseNullableDateTime(SanitizeJson(r.GetField("release_date"))));
        }

        private DateTime? ParseNullableDateTime(string dateTimeString)
        {
            if (DateTime.TryParse(dateTimeString, out var result))
            {
                return result;
            }
            return null;
        }

        private string SanitizeJson(string json)
        {
            return json.Replace(@"\x", "");
        }
    }
}
