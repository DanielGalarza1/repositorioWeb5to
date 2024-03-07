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
    public class DescripcionesController : ApiController
    {
        private AlarmasComunitariasEntities3 db = new AlarmasComunitariasEntities3();

        // GET: api/Descripciones
        public IQueryable<Descripciones> GetDescripciones()
        {
            return db.Descripciones;
        }

        // GET: api/Descripciones/5
        [ResponseType(typeof(Descripciones))]
        public IHttpActionResult GetDescripciones(int id)
        {
            Descripciones descripciones = db.Descripciones.Find(id);
            if (descripciones == null)
            {
                return NotFound();
            }

            return Ok(descripciones);
        }

        // PUT: api/Descripciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDescripciones(int id, Descripciones descripciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != descripciones.Id)
            {
                return BadRequest();
            }

            db.Entry(descripciones).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescripcionesExists(id))
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

        // POST: api/Descripciones
        [ResponseType(typeof(Descripciones))]
        public IHttpActionResult PostDescripciones(Descripciones descripciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Descripciones.Add(descripciones);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = descripciones.Id }, descripciones);
        }

        // DELETE: api/Descripciones/5
        [ResponseType(typeof(Descripciones))]
        public IHttpActionResult DeleteDescripciones(int id)
        {
            Descripciones descripciones = db.Descripciones.Find(id);
            if (descripciones == null)
            {
                return NotFound();
            }

            db.Descripciones.Remove(descripciones);
            db.SaveChanges();

            return Ok(descripciones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DescripcionesExists(int id)
        {
            return db.Descripciones.Count(e => e.Id == id) > 0;
        }
    }
}