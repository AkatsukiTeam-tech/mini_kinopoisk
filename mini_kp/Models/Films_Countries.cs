using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mini_kp.Models
{
    public class Films_Countries
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
