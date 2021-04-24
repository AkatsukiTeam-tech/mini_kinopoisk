using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mini_kp.Models
{
    public class Films_Users
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
