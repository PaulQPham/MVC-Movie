using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class MovieRolesController : Controller
    {
        private readonly MvcMovieContext _context;

        public MovieRolesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: MovieRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovieRole.ToListAsync());
        }

        // GET: MovieRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieRole = await _context.MovieRole
                .SingleOrDefaultAsync(m => m.ID == id);
            if (movieRole == null)
            {
                return NotFound();
            }

            return View(movieRole);
        }

        // GET: MovieRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Actor,Character,Movie")] MovieRole movieRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieRole);
        }

        // GET: MovieRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieRole = await _context.MovieRole.SingleOrDefaultAsync(m => m.ID == id);
            if (movieRole == null)
            {
                return NotFound();
            }
            return View(movieRole);
        }

        // POST: MovieRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Actor,Character,Movie")] MovieRole movieRole)
        {
            if (id != movieRole.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieRoleExists(movieRole.ID))
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
            return View(movieRole);
        }

        // GET: MovieRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieRole = await _context.MovieRole
                .SingleOrDefaultAsync(m => m.ID == id);
            if (movieRole == null)
            {
                return NotFound();
            }

            return View(movieRole);
        }

        // POST: MovieRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieRole = await _context.MovieRole.SingleOrDefaultAsync(m => m.ID == id);
            _context.MovieRole.Remove(movieRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieRoleExists(int id)
        {
            return _context.MovieRole.Any(e => e.ID == id);
        }
    }
}
