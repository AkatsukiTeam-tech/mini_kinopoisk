using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mini_kp.Data;
using mini_kp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mini_kp.Controllers
{
    public class HomeController : Controller
    {
        private readonly KPContext _context;

        public HomeController(KPContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Genres = _context.Genres;
            ViewBag.Actors = _context.Actors;
            return View(await _context.Films.ToListAsync());
        }

        public ActionResult SearchGenre(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Genre genre = _context.Genres.Find(id);

            if (genre == null)
            {
                return NotFound();
            }
            ViewBag.Genres = _context.Genres;
            ViewBag.Actors = _context.Actors;
            ViewBag.Countries = _context.Countries;
            return View(genre.Films);
        }

        public ActionResult Asc()
        {
            var film = _context.Films.OrderByDescending(f => f.KP_rate);

            ViewBag.Genres = _context.Genres;
            ViewBag.Actors = _context.Actors;
            return View(film);
        }
        public ActionResult Dsc()
        {
            var film = _context.Films.OrderBy(f => f.KP_rate);

            ViewBag.Genres = _context.Genres;
            ViewBag.Actors = _context.Actors;
            return View(film);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
