using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mini_kp.Models
{
    public class Films_Actors
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
