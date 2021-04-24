using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mini_kp.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ru_name { get; set; }
        public int Year { get; set; }
        public string Tagline { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public int Age_rating { get; set; }
        public int KP_rate { get; set; }
        public int IMDB_rate { get; set; }

        //public IList<Films_Actors> Films_Actors { get; set; }
        //public IList<Films_Genres> Films_Genres{ get; set; }
        //public IList<Films_Countries> Films_Countries{ get; set; }
        //public IList<Films_Users> Films_Users{ get; set; }

        public List<Genre> Genres { get; set; } = new List<Genre>(); 
        public List<Actor> Actors { get; set; } = new List<Actor>(); 
        public List<Country> Countries { get; set; } = new List<Country>(); 
        public List<User> Users { get; set; } = new List<User>(); 

    }
}
