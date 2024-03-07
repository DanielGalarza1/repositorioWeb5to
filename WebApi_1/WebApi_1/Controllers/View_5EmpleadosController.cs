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
using WebApi_1.Models;

namespace WebApi_1.Controllers
{
    public class View_5EmpleadosController : ApiController
    {
        private NorthwindEntities1 db = new NorthwindEntities1();

        // GET: api/View_5Empleados
        public IQueryable<View_5Empleados> GetView_5Empleados()
        {
            return db.View_5Empleados.OrderByDescending(v => v.monto);
        }

        [HttpGet]
        [Route("api/solo3")]
        public IQueryable<View_5Empleados> Get3Empleados()
        {
            return db.View_5Empleados.Take(3);
        }

        // GET: api/View_5Empleados/5
        [ResponseType(typeof(View_5Empleados))]
        public IHttpActionResult GetView_5Empleados(string id)
        {
            View_5Empleados view_5Empleados = db.View_5Empleados.Find(id);
            if (view_5Empleados == null)
            {
                return NotFound();
            }

            return Ok(view_5Empleados);
        }

        // PUT: api/View_5Empleados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutView_5Empleados(string id, View_5Empleados view_5Empleados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != view_5Empleados.Empleado)
            {
                return BadRequest();
            }

            db.Entry(view_5Empleados).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!View_5EmpleadosExists(id))
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

        // POST: api/View_5Empleados
        [ResponseType(typeof(View_5Empleados))]
        public IHttpActionResult PostView_5Empleados(View_5Empleados view_5Empleados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.View_5Empleados.Add(view_5Empleados);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (View_5EmpleadosExists(view_5Empleados.Empleado))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = view_5Empleados.Empleado }, view_5Empleados);
        }

        // DELETE: api/View_5Empleados/5
        [ResponseType(typeof(View_5Empleados))]
        public IHttpActionResult DeleteView_5Empleados(string id)
        {
            View_5Empleados view_5Empleados = db.View_5Empleados.Find(id);
            if (view_5Empleados == null)
            {
                return NotFound();
            }

            db.View_5Empleados.Remove(view_5Empleados);
            db.SaveChanges();

            return Ok(view_5Empleados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool View_5EmpleadosExists(string id)
        {
            return db.View_5Empleados.Count(e => e.Empleado == id) > 0;
        }
    }
}