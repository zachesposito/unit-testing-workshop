using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnitTestingWorkshop.Demo.Services.Movies.Models;

namespace UnitTestingWorkshop.Demo.Services.Movies
{
    /// <summary>
    /// Provides movie data from CSV files
    /// </summary>
    public class CSVMovieDataService : IMovieDataService
    {
        public IEnumerable<Movie> LoadMovies()
        {
            var movies = ParseCSVFile<Movie>(@"Movies\Data\movies_metadata.csv");

            return movies;
        }

        private IEnumerable<T> ParseCSVFile<T>(string path)
        {
            if (File.Exists(path))
            {
                using (TextReader textReader = File.OpenText(path))
                {
                    var csvParser = new CsvReader(textReader);
                    csvParser.Configuration.RegisterClassMap<MovieCSVMap>();
                    csvParser.Configuration.TrimOptions = TrimOptions.InsideQuotes;
                    csvParser.Configuration.ShouldSkipRecord = record => record.Any(f => f.Contains(@"\r"));
                    csvParser.Configuration.PrepareHeaderForMatch = header => StandardizeNameForMatch(header);
                    csvParser.Configuration.BadDataFound = (context) =>
                    {
                        Console.WriteLine("Bad data found: " + context.FieldBuilder + " in record " + context.RawRecordBuilder + ". Skipped.");
                    };
                    return csvParser.GetRecords<T>().ToList();
                }
            }
            else
            {
                throw new FileNotFoundException($"Could not find CSV file at {path}.");
            }
        }
        private string StandardizeNameForMatch(string str)
        {
            var result = str.Replace("_", "").ToLower();
            return result;
        }
    }
}