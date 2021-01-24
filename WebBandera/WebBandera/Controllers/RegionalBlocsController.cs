using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebBandera.Models;

namespace WebBandera.Controllers
{
    public class RegionalBlocsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/RegionalBlocs
        public IQueryable<RegionalBloc> GetRegionalBlocs()
        {
            return db.RegionalBlocs;
        }

        // GET: api/RegionalBlocs/5
        [ResponseType(typeof(RegionalBloc))]
        public IHttpActionResult GetRegionalBloc(string id)
        {
            RegionalBloc regionalBloc = db.RegionalBlocs.Find(id);
            if (regionalBloc == null)
            {
                return NotFound();
            }

            return Ok(regionalBloc);
        }

        // PUT: api/RegionalBlocs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegionalBloc(string id, RegionalBloc regionalBloc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != regionalBloc.acronym)
            {
                return BadRequest();
            }

            db.Entry(regionalBloc).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionalBlocExists(id))
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

        // POST: api/RegionalBlocs
        [ResponseType(typeof(RegionalBloc))]
        public IHttpActionResult PostRegionalBloc(RegionalBloc regionalBloc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RegionalBlocs.Add(regionalBloc);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RegionalBlocExists(regionalBloc.acronym))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = regionalBloc.acronym }, regionalBloc);
        }

        // DELETE: api/RegionalBlocs/5
        [ResponseType(typeof(RegionalBloc))]
        public IHttpActionResult DeleteRegionalBloc(string id)
        {
            RegionalBloc regionalBloc = db.RegionalBlocs.Find(id);
            if (regionalBloc == null)
            {
                return NotFound();
            }

            db.RegionalBlocs.Remove(regionalBloc);
            db.SaveChanges();

            return Ok(regionalBloc);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegionalBlocExists(string id)
        {
            return db.RegionalBlocs.Count(e => e.acronym == id) > 0;
        }
    }
}