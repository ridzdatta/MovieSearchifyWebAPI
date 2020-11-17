using MovieSearchifyWebAPI.Interfaces;
using MovieSearchifyWebAPI.Models;
using MovieSearchifyWebAPI.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace MovieSearchifyWebAPI.Controllers
{
    public class MoviesController : ApiController
    {
        [System.Web.Http.HttpGet]
        [EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
        public string Get()
        {
            IMoviesServices moviesService = new MoviesService();
            return JsonConvert.SerializeObject(moviesService.GetAllMovies());
        }
        [System.Web.Http.HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public string Get(string id)
        {
            IMoviesServices moviesService = new MoviesService();
            return JsonConvert.SerializeObject(moviesService.GetMovieById(id));
        }
    }
}