using MovieSearchifyWebAPI.Interfaces;
using MovieSearchifyWebAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MovieSearchifyWebAPI.Services
{
    public class MoviesService: IMoviesServices
    {
        public IEnumerable<Movie> GetAllMovies()
        {
            var path = WebConfigurationManager.AppSettings["MoviesPath"];
            path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, path);
            var json = File.ReadAllText(path);
            var moviesList = new List<Movie>();
            try
            {
                var jObject = JObject.Parse(json);
                if (jObject != null)
                {
                    if (moviesList != null)
                    {
                        var strJsonMoviesList = jObject["movies"]?.ToString();
                        moviesList = (JsonConvert.DeserializeObject<List<Movie>>(strJsonMoviesList));

                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return moviesList;
        }
        public Movie GetMovieById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return new Movie();
            }
            try
            {
                var listOfMovies = GetAllMovies();
                return listOfMovies.Where(x => id.Equals(x?.ImdbID, StringComparison.OrdinalIgnoreCase))?.FirstOrDefault();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}