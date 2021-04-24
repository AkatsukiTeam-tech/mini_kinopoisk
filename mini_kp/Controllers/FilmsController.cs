using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mini_kp.Data;
using mini_kp.Models;

namespace mini_kp.Controllers
{
    public class FilmsController : Controller
    {
        private readonly KPContext _context;

        public FilmsController(KPContext context)
        {
            _context = context;
        }

        // GET: Films
        public async Task<IActionResult> Index()
        {
            return View(await _context.Films.ToListAsync());
        }

        // GET: Films/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            //get genres
            var film = await _context.Films
                .FirstOrDefaultAsync(f => f.Id == id);

            if (film == null)
            {
                return NotFound();
            }

            List<Genre> genres = new List<Genre>();
            //List<Actor> actors = new List<Actor>();

            foreach(var g in film.Genres){
                genres.Add(g);
            }

            /*foreach(var a in film.Actors){
                actors.Add(a);
            }*/

            ViewBag.Genres = genres;
            //ViewBag.Actors = actors;


            return View(film);
        }

        // GET: Films/Create
        public IActionResult Create()
        {
            ViewBag.Genres = _context.Genres;
            ViewBag.Actors = _context.Actors;
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Ru_name,Year,Tagline,Description,Poster,Age_rating,KP_rate,IMDB_rate")] Film film, int[] genreId, int[] actorId)
        {

            film.Genres.Clear();
            if (genreId != null)
            {
                foreach (var g in _context.Genres.Where(genre => genreId.Contains(genre.Id)))
                {
                    film.Genres.Add(g);
                }
            }

            film.Actors.Clear();
            if (actorId != null)
            {
                foreach (var a in _context.Actors.Where(actor => actorId.Contains(actor.Id)))
                {
                    film.Actors.Add(a);
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(film);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Actors = _context.Actors.ToList();

            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Ru_name,Year,Tagline,Description,Poster,Age_rating,KP_rate,IMDB_rate")] Film film, int[] genreId, int[] actorId)
        {
            if (id != film.Id)
            {
                return NotFound();
            }

            film.Genres.Clear();
            if (genreId != null)
            {
                foreach (var g in _context.Genres.Where(genre => genreId.Contains(genre.Id)))
                {
                    film.Genres.Add(g);
                }
            }

            film.Actors.Clear();
            if (actorId != null)
            {
                foreach (var a in _context.Actors.Where(actor => actorId.Contains(actor.Id)))
                {
                    film.Actors.Add(a);
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(film);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmExists(film.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        // GET: Films/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Films
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await _context.Films.FindAsync(id);
            _context.Films.Remove(film);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
            return _context.Films.Any(e => e.Id == id);
        }
    }
}
