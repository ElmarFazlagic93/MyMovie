using MyMovie.Data;
using MyMovie.Helper;
using MyMovie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace MyMovie.Controllers
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [JwtAuthentication]
        // GET: api/Movies
        public IQueryable<Movie> GetMovies()
        {
            return db.Movies.Include(r => r.Rating).Include(s => s.Stars).Include(t => t.ShowType);
        }

        // GET: api/Movies/5
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> GetMovie(int id)
        {
            Movie movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [JwtAuthentication]
        // GET: api/Movies/ByType/
        [ResponseType(typeof(IQueryable<Movie>))]
        [Route("api/Movies/ByType/{typeId}")]
        public IQueryable<Movie> GetMoviebyType(int typeId)
        {
            return db.Movies.Where(x => x.ShowTypeId == typeId).Include(r => r.Rating).Include(s => s.Stars);
        }

        [JwtAuthentication]
        // GET: api/Movies/GetTop10Movies/
        [ResponseType(typeof(IQueryable<Movie>))]
        [Route("api/Movies/GetTop10Movies")]
        public IQueryable<Movie> GetTop10Movies()
        {
            ShowType type = db.ShowTypes.FirstOrDefault(x => x.Name == "Movie");
            List<Movie> movies = new List<Movie>();
            movies = db.Movies.Where(x => x.ShowTypeId == type.Id).Include(r => r.Rating).Include(s => s.Stars).ToList();


            foreach (var movie in movies)
            {
                movie.AverageRating = GetAverageRating(movie.Id);
            }

            List<Movie> sortedMovies = new List<Movie>();
            sortedMovies = movies.OrderByDescending(o => o.AverageRating).ToList();

            return sortedMovies.Take(10).AsQueryable();
        }

        [JwtAuthentication]
        // GET: api/Movies/GetTop10TvShows/
        [ResponseType(typeof(IQueryable<Movie>))]
        [Route("api/Movies/GetTop10TvShows")]
        public IQueryable<Movie> GetTop10TvShows()
        {
            ShowType type = db.ShowTypes.FirstOrDefault(x => x.Name == "TV Show");
            List<Movie> movies = new List<Movie>();
            movies = db.Movies.Where(x => x.ShowTypeId == type.Id).Include(r => r.Rating).Include(s => s.Stars).ToList();

            foreach (var movie in movies)
            {
                movie.AverageRating = GetAverageRating(movie.Id);
            }

            List<Movie> sortedMovies = new List<Movie>();
            sortedMovies = movies.OrderByDescending(o => o.AverageRating).ToList();

            return sortedMovies.Take(10).AsQueryable();
        }

        [JwtAuthentication]
        // GET: api/Movies/getAverageRating/5
        [ResponseType(typeof(double))]
        [Route("api/Movies/GetAverageRating/{movieId}")]
        public double GetAverageRating(int movieId)
        {
            Movie movie = db.Movies.FirstOrDefault(x => x.Id == movieId);
            List<Rating> ratings = new List<Rating>();
            ratings = movie.Rating.ToList();
            double sum = 0;

            foreach (var rating in ratings)
            {
                sum += rating.RateNumber;
            }

            return Math.Round(double.Parse((sum / ratings.Count).ToString()),2);
        }

        [JwtAuthentication]
        // GET: api/Movies/Search/{searchText}
        [ResponseType(typeof(PagedData<Movie>))]
        [Route("api/Movies/SearchMovies/{searchText}/{pageNumber}/{pageSize}")]
        [HttpGet]
        public PagedData<Movie> SearchMovies(string searchText, int pageNumber = 1, int pageSize = 10)
        {
            List<Movie> movies = new List<Movie>();
            string searchTextlower = searchText.ToLower();
            movies = db.Movies.Where(x => x.Name.ToLower().Contains(searchTextlower) || x.Description.ToLower().Contains(searchTextlower)).Include(r => r.Rating).Include(s => s.Stars).Include(t => t.ShowType).ToList();

            foreach (var movie in movies)
            {
                movie.AverageRating = GetAverageRating(movie.Id);
            }

            List<Movie> sortedMovies = new List<Movie>();
            sortedMovies = movies.OrderByDescending(o => o.AverageRating).ToList();

            return Paggination.PagedResult(sortedMovies, pageNumber, pageSize);
        }

        [JwtAuthentication]
        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.Id)
            {
                return BadRequest();
            }

            db.Entry(movie).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [JwtAuthentication]
        // POST: api/Movies
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Movies.Add(movie);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = movie.Id }, movie);
        }

        [JwtAuthentication]
        // DELETE: api/Movies/5
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> DeleteMovie(int id)
        {
            Movie movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movie);
            await db.SaveChangesAsync();

            return Ok(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(int id)
        {
            return db.Movies.Count(e => e.Id == id) > 0;
        }
    }
}