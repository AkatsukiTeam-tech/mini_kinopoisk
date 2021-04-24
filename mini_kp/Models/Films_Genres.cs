using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mini_kp.Models
{
    public class Films_Genres
    {
        public int FilmsId { get; set; }
        public Film Film { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
