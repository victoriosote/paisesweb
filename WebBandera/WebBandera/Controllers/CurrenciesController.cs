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
    public class CurrenciesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Currencies
        public IQueryable<Currency> GetCurrencies()
        {
            return db.Currencies;
        }

        // GET: api/Currencies/5
        [ResponseType(typeof(Currency))]
        public IHttpActionResult GetCurrency(string id)
        {
            Currency currency = db.Currencies.Find(id);
            if (currency == null)
            {
                return NotFound();
            }

            return Ok(currency);
        }

        // PUT: api/Currencies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCurrency(string id, Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != currency.code)
            {
                return BadRequest();
            }

            db.Entry(currency).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyExists(id))
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

        // POST: api/Currencies
        [ResponseType(typeof(Currency))]
        public IHttpActionResult PostCurrency(Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Currencies.Add(currency);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CurrencyExists(currency.code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = currency.code }, currency);
        }

        // DELETE: api/Currencies/5
        [ResponseType(typeof(Currency))]
        public IHttpActionResult DeleteCurrency(string id)
        {
            Currency currency = db.Currencies.Find(id);
            if (currency == null)
            {
                return NotFound();
            }

            db.Currencies.Remove(currency);
            db.SaveChanges();

            return Ok(currency);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CurrencyExists(string id)
        {
            return db.Currencies.Count(e => e.code == id) > 0;
        }
    }
}