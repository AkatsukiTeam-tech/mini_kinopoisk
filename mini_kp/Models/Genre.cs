using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mini_kp.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public IList<Films_Genres> Films_Genres { get; set; }

        public List<Film> Films { get; set; } = new List<Film>();
    }
}
