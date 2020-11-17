using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieSearchifyWebAPI.Models
{
    public class MovieShow
    {
        public int Id { get; set; }
        public DateTime timing { get; set; }
        public string HallId { get; set; }
    }
}