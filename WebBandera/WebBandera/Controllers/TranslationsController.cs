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
    public class TranslationsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Translations
        public IQueryable<Translations> GetTranslations()
        {
            return db.Translations;
        }

        // GET: api/Translations/5
        [ResponseType(typeof(Translations))]
        public IHttpActionResult GetTranslations(string id)
        {
            Translations translations = db.Translations.Find(id);
            if (translations == null)
            {
                return NotFound();
            }

            return Ok(translations);
        }

        // PUT: api/Translations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTranslations(string id, Translations translations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != translations.de)
            {
                return BadRequest();
            }

            db.Entry(translations).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TranslationsExists(id))
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

        // POST: api/Translations
        [ResponseType(typeof(Translations))]
        public IHttpActionResult PostTranslations(Translations translations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Translations.Add(translations);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TranslationsExists(translations.de))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = translations.de }, translations);
        }

        // DELETE: api/Translations/5
        [ResponseType(typeof(Translations))]
        public IHttpActionResult DeleteTranslations(string id)
        {
            Translations translations = db.Translations.Find(id);
            if (translations == null)
            {
                return NotFound();
            }

            db.Translations.Remove(translations);
            db.SaveChanges();

            return Ok(translations);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TranslationsExists(string id)
        {
            return db.Translations.Count(e => e.de == id) > 0;
        }
    }
}