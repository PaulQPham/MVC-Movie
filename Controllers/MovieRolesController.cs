using System;
using System.Collections.Generic;
using System.Web;
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
        static string referrer;

        private readonly MvcMovieContext _context;

        public MovieRolesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: MovieRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovieRole.Include(r => r.Actor).Include(r => r.Movie).ToListAsync());
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
    
        public async Task<IActionResult> Create(string newRole, string newActor, string newMovie)
        {
            //creates a new MovieRole and adds to DB
            var movieRole = new MovieRole
            {
                Actor = _context.Actor.Where(a => a.Name == newActor).First(),
                Character = newRole,
                Movie = _context.Movie.Where(m => m.Title == newMovie).First()
            };

            _context.Add(movieRole);
            await _context.SaveChangesAsync();
            return Json(new { Result = "Success", Message = "New Role Added"} );

     
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
        public async Task<IActionResult> Delete(int? id, string actorName, string movieTitle)
        {
            if (actorName != null && movieTitle != null)
            {
                id = (from r in _context.MovieRole
                     where r.Actor.Name == actorName && r.Movie.Title == movieTitle
                     select r.ID).SingleOrDefault();
            }

            if (id == null)
            {
                return NotFound();
            }

            var movieRole = await _context.MovieRole.Include(r => r.Actor).Include(r => r.Movie).SingleOrDefaultAsync(r => r.ID == id);


            if (movieRole == null)
            {
                return NotFound();
            }

            referrer = HttpContext.Request.Headers["Referer"].ToString();

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
            //Returns to either Movie edit page or Actor edit page instead of MovieRoles/Index
            return Redirect(referrer);
        }

        public async Task<IActionResult> Back()
        {
            //Returns to either Movie edit page or Actor edit page instead of MovieRoles/Index
            return Redirect(referrer);
        }

        private bool MovieRoleExists(int id)
        {
            return _context.MovieRole.Any(e => e.ID == id);
        }
    }
}
