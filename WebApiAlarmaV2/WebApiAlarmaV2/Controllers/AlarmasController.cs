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
using WebApiAlarmaV2.Models;

namespace WebApiAlarmaV2.Controllers
{
    public class AlarmasController : ApiController
    {
        private AlarmasComunitariasEntities3 db = new AlarmasComunitariasEntities3();

        // GET: api/Alarmas
        public IQueryable<Alarmas> GetAlarmas()
        {
            return db.Alarmas;
        }

        // GET: api/Alarmas/5
        [ResponseType(typeof(Alarmas))]
        public IHttpActionResult GetAlarmas(int id)
        {
            Alarmas alarmas = db.Alarmas.Find(id);
            if (alarmas == null)
            {
                return NotFound();
            }

            return Ok(alarmas);
        }

        // PUT: api/Alarmas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlarmas(int id, Alarmas alarmas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alarmas.Id)
            {
                return BadRequest();
            }

            db.Entry(alarmas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlarmasExists(id))
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

        // POST: api/Alarmas
        [ResponseType(typeof(Alarmas))]
        public IHttpActionResult PostAlarmas(Alarmas alarmas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Alarmas.Add(alarmas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = alarmas.Id }, alarmas);
        }

        // DELETE: api/Alarmas/5
        [ResponseType(typeof(Alarmas))]
        public IHttpActionResult DeleteAlarmas(int id)
        {
            Alarmas alarmas = db.Alarmas.Find(id);
            if (alarmas == null)
            {
                return NotFound();
            }

            db.Alarmas.Remove(alarmas);
            db.SaveChanges();

            return Ok(alarmas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlarmasExists(int id)
        {
            return db.Alarmas.Count(e => e.Id == id) > 0;
        }
    }
}