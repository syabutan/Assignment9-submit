using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment3.Models;

namespace Assignment3.Controllers
{
    public class MovieInfoesController : Controller
    {
        private readonly MovieDbContext _context;

        public MovieInfoesController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: MovieInfoes
        public async Task<IActionResult> Collection()
        {
            return View(await _context.Movies.ToListAsync());
        }

        // GET: MovieInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieInfo = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieInfo == null)
            {
                return NotFound();
            }

            return View(movieInfo);
        }

        // GET: MovieInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,Category,Title,Year,Director,Rating,Edited,Lent_to,Notes")] MovieInfo movieInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Collection", movieInfo);
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MyPodcasts()
        {
            return View();
        }


        // GET: MovieInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieInfo = await _context.Movies.FindAsync(id);
            if (movieInfo == null)
            {
                return NotFound();
            }
            return View(movieInfo);
        }

        // POST: MovieInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,Category,Title,Year,Director,Rating,Edited,Lent_to,Notes")] MovieInfo movieInfo)
        {
            if (id != movieInfo.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieInfoExists(movieInfo.MovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Collection");
            }
            return View();
        }

        // GET: MovieInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieInfo = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieInfo == null)
            {
                return NotFound();
            }

            return View(movieInfo);
        }

        // POST: MovieInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieInfo = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movieInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieInfoExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
