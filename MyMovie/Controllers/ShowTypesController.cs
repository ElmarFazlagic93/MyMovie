using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MyMovie.Data;
using MyMovie.Helper;
using MyMovie.Models;

namespace MyMovie.Controllers
{
    public class ShowTypesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [JwtAuthentication]
        // GET: api/ShowTypes
        public IQueryable<ShowType> GetShowTypes()
        {
            return db.ShowTypes;
        }

        [JwtAuthentication]
        // GET: api/ShowTypes/5
        [ResponseType(typeof(ShowType))]
        public async Task<IHttpActionResult> GetShowType(int id)
        {
            ShowType showType = await db.ShowTypes.FindAsync(id);
            if (showType == null)
            {
                return NotFound();
            }

            return Ok(showType);
        }

        [JwtAuthentication]
        // PUT: api/ShowTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutShowType(int id, ShowType showType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != showType.Id)
            {
                return BadRequest();
            }

            db.Entry(showType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowTypeExists(id))
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
        // POST: api/ShowTypes
        [ResponseType(typeof(ShowType))]
        public async Task<IHttpActionResult> PostShowType(ShowType showType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ShowTypes.Add(showType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = showType.Id }, showType);
        }

        [JwtAuthentication]
        // DELETE: api/ShowTypes/5
        [ResponseType(typeof(ShowType))]
        public async Task<IHttpActionResult> DeleteShowType(int id)
        {
            ShowType showType = await db.ShowTypes.FindAsync(id);
            if (showType == null)
            {
                return NotFound();
            }

            db.ShowTypes.Remove(showType);
            await db.SaveChangesAsync();

            return Ok(showType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShowTypeExists(int id)
        {
            return db.ShowTypes.Count(e => e.Id == id) > 0;
        }
    }
}