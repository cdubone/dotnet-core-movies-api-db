using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [Route("api/movies")]
    public class MoviesController : Controller
    {
        private readonly MoviesAPIContext _context;

        public MoviesController(MoviesAPIContext context)
        {
            _context = context;    
        }


        [HttpGet()]
        public IActionResult GetMovies()
        {
            var movies = from m in _context.Movie
                         select m;

            return new JsonResult(movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _context.Movie.FirstOrDefault(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost()]
        public ActionResult CreateMovie([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Add(movie);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateMovie(int id, [FromBody] JsonPatchDocument<Movie> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            return NoContent();
        }


        // GET api/movies
        //[HttpGet]
        //public IEnumerable<Movie> Get()
        //{
        //    //// Use LINQ to get list of genres.
        //    //IQueryable<string> genreQuery = from m in _context.Movie
        //                                    //orderby m.Genre
        //                                    //select m.Genre;

        //    var movies = from m in _context.Movie
        //                 select m;

        //    return movies;
        //}

        // GET api/movies/5
        //[HttpGet("{id}")]
        //public Movie Get(int id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    var movie = _context.Movie
        //        .SingleOrDefault(m => m.ID == id);
        //    //if (movie == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    return movie;
        //}

        //// GET: Movies
        //// Requires using Microsoft.AspNetCore.Mvc.Rendering;
        //public async Task<IActionResult> Index(string movieGenre, string searchString)
        //{
        //    // Use LINQ to get list of genres.
        //    IQueryable<string> genreQuery = from m in _context.Movie
        //                                    orderby m.Genre
        //                                    select m.Genre;

        //    var movies = from m in _context.Movie
        //                 select m;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        movies = movies.Where(s => s.Title.Contains(searchString));
        //    }

        //    if (!String.IsNullOrEmpty(movieGenre))
        //    {
        //        movies = movies.Where(x => x.Genre == movieGenre);
        //    }

        //    var movieGenreVM = new MovieGenreViewModel();
        //    movieGenreVM.genres = new SelectList(await genreQuery.Distinct().ToListAsync());
        //    movieGenreVM.movies = await movies.ToListAsync();

        //    return View(movieGenreVM);
        //}

        //// GET: Movies/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var movie = await _context.Movie
        //        .SingleOrDefaultAsync(m => m.ID == id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(movie);
        //}

        //// GET: Movies/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Movies/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(movie);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(movie);
        //}

        //// GET: Movies/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(movie);
        //}

        //// POST: Movies/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Price,Rating")]Movie movie)
        //{
        //    if (id != movie.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(movie);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!MovieExists(movie.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    return View(movie);
        //}

        //// GET: Movies/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var movie = await _context.Movie
        //        .SingleOrDefaultAsync(m => m.ID == id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(movie);
        //}

        //// POST: Movies/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
        //    _context.Movie.Remove(movie);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //private bool MovieExists(int id)
        //{
        //    return _context.Movie.Any(e => e.ID == id);
        //}
    }
}
