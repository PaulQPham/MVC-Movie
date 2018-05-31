using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using PagedList;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMovieContext _context;

        public MoviesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Movies
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string movieGenre, string movieString, string actor, int? movieID, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.GenreSortParm = sortOrder == "Genre" ? "genre_desc" : "Genre";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.RatingSortParm = sortOrder == "Rating" ? "rating_desc" : "Rating";

            if (actor != null)
            {
                page = 1;
            }
            else
            {
                actor = currentFilter;
            }

            ViewBag.CurrentFilter = actor;
            ViewBag.CurrentPage = page;

            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            IQueryable<string> actorQuery = from m in _context.MovieRole
                                     
                                            where m.Actor.Name == actor
                                            select m.Movie.Title;

            IQueryable<LoadMovieRole> roleQuery = from r in _context.MovieRole
                            join m in _context.Movie on r.Movie equals m
                            join a in _context.Actor on r.Actor equals a
                            where r.Movie.ID == movieID
                            select new LoadMovieRole { Actor = a.Name, Character = r.Character, Movie = m.Title} ;

            var movies = from m in _context.Movie
                         select m;

            if (!String.IsNullOrEmpty(movieString))
            {
                movies = movies.Where(s => s.Title.Contains(movieString));
            }

            if (!String.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            if (!String.IsNullOrEmpty(actor))
            {
                movies = movies.Where(m => actorQuery.Contains(m.Title));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    movies = movies.OrderByDescending(m => m.Title);
                    break;
                case "Date":
                    movies = movies.OrderBy(m => m.ReleaseDate);
                    break;
                case "date_desc":
                    movies = movies.OrderByDescending(m => m.ReleaseDate);
                    break;
                case "Genre":
                    movies = movies.OrderBy(m => m.Genre);
                    break;
                case "genre_desc":
                    movies = movies.OrderByDescending(m => m.Genre);
                    break;
                case "Price":
                    movies = movies.OrderBy(m => m.Price);
                    break;
                case "price_desc":
                    movies = movies.OrderByDescending(m => m.Price);
                    break;
                case "Rating":
                    movies = movies.OrderBy(m => m.Rating);
                    break;
                case "rating_desc":
                    movies = movies.OrderByDescending(m => m.Rating);
                    break;
                default:
                    movies = movies.OrderBy(m => m.Title);
                    break;
            }

            roleQuery = roleQuery.OrderBy(r => r.Actor);

            //if (movieID == null && movies.Any())
            //{
            //    movieID = movies.First().ID;
            //}

            var movieGenreVM = new MovieGenreViewModel();
            movieGenreVM.genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            movieGenreVM.movies = await PaginatedList<Movie>.CreateAsync(movies.AsNoTracking(), page ?? 1, 7);
            movieGenreVM.roles = roleQuery;

            if (movies.Any() && movieID != null)
            {
                movieGenreVM.selectedMovie = movies.Where(x => x.ID == movieID).First();
            }
            
            return View(movieGenreVM);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        public async Task<IActionResult> Details(int? id, string title)
        {
            var movieCastVM = new MovieCastViewModel();

            if (id == null && title == null)
            {
                return NotFound();
            }
            else if (id == null)
            {
                id = _context.Movie.Where(m => m.Title == title).First().ID;
            }

            var movie = await _context.Movie
                .SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            movieCastVM.movie = movie;
            movieCastVM.roles = from r in _context.MovieRole
                                join m in _context.Movie on r.Movie equals m
                                join a in _context.Actor on r.Actor equals a
                                where r.Movie.ID == id
                                select new LoadMovieRole { Actor = a.Name, Character = r.Character, Movie = m.Title };

            return View(movieCastVM);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre,Price,Rating,Image")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var movieCastVM = new MovieCastViewModel();

            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            movieCastVM.movie = movie;
            movieCastVM.roles = from r in _context.MovieRole
                                join m in _context.Movie on r.Movie equals m
                                join a in _context.Actor on r.Actor equals a
                                where r.Movie.ID == id
                                select new LoadMovieRole { Actor = a.Name, Character = r.Character, Movie = m.Title };

            return View(movieCastVM);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Price,Rating,Image")] Movie movie)
        {
            if (id != movie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.ID))
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
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _context.MovieRole.RemoveRange(_context.MovieRole.Where(m => m.Movie.ID == id));
            
            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
    }
}
