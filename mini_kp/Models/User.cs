using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mini_kp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Full_name { get; set; }
        //public IList<Films_Users> Films_Users { get; set; }
        public List<Film> Films { get; set; } = new List<Film>();
    }
}
