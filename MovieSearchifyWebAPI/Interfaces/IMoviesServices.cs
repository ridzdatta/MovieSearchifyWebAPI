using MovieSearchifyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieSearchifyWebAPI.Interfaces
{
    public interface IMoviesServices
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(string id);
    }
}