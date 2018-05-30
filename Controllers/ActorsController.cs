using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using PagedList.EntityFramework;
using PagedList;


namespace MvcMovie.Controllers
{
    public class ActorsController : Controller
    {
        private readonly MvcMovieContext _context;

        public ActorsController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Actors
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.HometownSortParm = sortOrder == "Hometown" ? "hometown_desc" : "Hometown";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var actors = from a in _context.Actor
                           select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                actors = actors.Where(a => a.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    actors = actors.OrderByDescending(a => a.Name);
                    break;
                case "Date":
                    actors = actors.OrderBy(a => a.BirthDate);
                    break;
                case "date_desc":
                    actors = actors.OrderByDescending(a => a.BirthDate);
                    break;
                case "Hometown":
                    actors = actors.OrderBy(a => a.Hometown);
                    break;
                case "hometown_desc":
                    actors = actors.OrderByDescending(a => a.Hometown);
                    break;
                default:
                    actors = actors.OrderBy(a => a.Name);
                    break;
            }

            return View(await PaginatedList<Actor>.CreateAsync(actors.AsNoTracking(), page ?? 1, 10));
        }

        // GET: Actors/Details/5
        public async Task<IActionResult> Details(int? id, string actorName)
        {
            var movieCastVM = new MovieCastViewModel();

            if (id == null && actorName == null)
            {
                return NotFound();
            }
            else if (id == null)
            {
                id = (from m in _context.Actor
                     where m.Name == actorName
                     select m.ID).First();
            }

            var actor = await _context.Actor
                .SingleOrDefaultAsync(m => m.ID == id);
            if (actor == null)
            {
                return NotFound();
            }

            movieCastVM.actor = _context.Actor.Where(a => a.ID == id).First();
            movieCastVM.roles = from r in _context.MovieRole
                                join m in _context.Movie on r.Movie equals m
                                join a in _context.Actor on r.Actor equals a
                                where r.Actor.ID == id
                                select new LoadMovieRole { Actor = a.Name, Character = r.Character, Movie = m.Title };

            return View(movieCastVM);
        }

        // GET: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,BirthDate,Hometown,BirthName")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        // GET: Actors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actor.SingleOrDefaultAsync(m => m.ID == id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,BirthDate,Hometown,BirthName")] Actor actor)
        {
            if (id != actor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorExists(actor.ID))
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
            return View(actor);
        }

        // GET: Actors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actor
                .SingleOrDefaultAsync(m => m.ID == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actor = await _context.Actor.SingleOrDefaultAsync(m => m.ID == id);
            _context.Actor.Remove(actor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorExists(int id)
        {
            return _context.Actor.Any(e => e.ID == id);
        }
    }
}
