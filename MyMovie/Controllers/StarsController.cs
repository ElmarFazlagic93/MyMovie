using MyMovie.Data;
using MyMovie.Helper;
using MyMovie.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace MyMovie.Controllers
{
    public class StarsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [JwtAuthentication]
        // GET: api/Stars
        public IQueryable<Star> GetStars()
        {
            return db.Stars;
        }

        [JwtAuthentication]
        // GET: api/Stars/5
        [ResponseType(typeof(Star))]
        public async Task<IHttpActionResult> GetStar(int id)
        {
            Star star = await db.Stars.FindAsync(id);
            if (star == null)
            {
                return NotFound();
            }

            return Ok(star);
        }

        [JwtAuthentication]
        // PUT: api/Stars/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStar(int id, Star star)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != star.Id)
            {
                return BadRequest();
            }

            db.Entry(star).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StarExists(id))
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
        // POST: api/Stars
        [ResponseType(typeof(Star))]
        public async Task<IHttpActionResult> PostStar(Star star)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stars.Add(star);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = star.Id }, star);
        }

        [JwtAuthentication]
        // DELETE: api/Stars/5
        [ResponseType(typeof(Star))]
        public async Task<IHttpActionResult> DeleteStar(int id)
        {
            Star star = await db.Stars.FindAsync(id);
            if (star == null)
            {
                return NotFound();
            }

            db.Stars.Remove(star);
            await db.SaveChangesAsync();

            return Ok(star);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StarExists(int id)
        {
            return db.Stars.Count(e => e.Id == id) > 0;
        }
    }
}