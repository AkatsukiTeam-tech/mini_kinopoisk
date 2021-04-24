using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mini_kp.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Full_name { get; set; }
        //public IList<Films_Actors> Films_Actors { get; set; }

        public List<Film> Films { get; set; } = new List<Film>();
    }
}
