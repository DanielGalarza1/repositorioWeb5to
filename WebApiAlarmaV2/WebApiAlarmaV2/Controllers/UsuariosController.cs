using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApiAlarmaV2.Models;

namespace WebApiAlarmaV2.Controllers
{
    public class UsuariosController : ApiController
    {
        private AlarmasComunitariasEntities3 db = new AlarmasComunitariasEntities3();

        // GET: api/Usuarios
        public IQueryable<Usuarios> GetUsuarios()
        {
            return db.Usuarios;
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult GetUsuarios(string id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuarios(string id, Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarios.Cedula)
            {
                return BadRequest();
            }

            db.Entry(usuarios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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

        [HttpPut]
        [Route("api/EditarUsuarios/{id}")]
        public IHttpActionResult EditarUsuarios(string id, Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarios.Cedula)
            {
                return BadRequest();
            }

            // Obtener el usuario existente de la base de datos
            var existingUser = db.Usuarios.Find(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            // Actualizar solo los campos relevantes, excepto la contraseña
            existingUser.Cedula = usuarios.Cedula;
            existingUser.Nombre = usuarios.Nombre;
            existingUser.Apellido = usuarios.Apellido;
            existingUser.Telefono = usuarios.Telefono;
            existingUser.CallePrincipal = usuarios.CallePrincipal;
            existingUser.CalleSecundaria = usuarios.CalleSecundaria;
            existingUser.Latitud = usuarios.Latitud;
            existingUser.Longitud = usuarios.Longitud;
            existingUser.PisoApartamento = usuarios.PisoApartamento;
            existingUser.Sector = usuarios.Sector;
            existingUser.FormularioCompletado = usuarios.FormularioCompletado;
            // Actualizar los demás campos según corresponda

            db.Entry(existingUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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


        // POST: api/Usuarios
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult PostUsuarios(Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuarios.Add(usuarios);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UsuariosExists(usuarios.Cedula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = usuarios.Cedula }, usuarios);
        }

        //Login Con Web Token 
        [HttpPost]
        [Route("api/Usuarios/Login/{cedula}/{contrasena}")]
        public IHttpActionResult Login(string cedula, string contrasena)
        {
            // Aquí debes implementar la lógica para verificar el nombre de usuario y contraseña en tu sistema.
            // Si las credenciales son válidas, puedes generar el token y devolverlo al cliente.

            Usuarios usuario = db.Usuarios.FirstOrDefault(u => u.Cedula == cedula && u.Contraseña == contrasena);

            if (usuario != null)
            {
                var token = TokenManager.GenerateToken(usuario.Cedula);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }


        [HttpGet]
        [Route("api/Usuarios/Autorizacion")]
        [Authorize]
        public IHttpActionResult ProtectedMethod()
        {
            // Este método está protegido con autenticación.
            // Solo los clientes con un token válido podrán acceder a él.

            var principal = TokenManager.GetPrincipal(Request.Headers.Authorization.Parameter);
            var username = principal?.Identity?.Name;

            return Ok($"Hola, {username}! Este es un método protegido.");
        }


        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult DeleteUsuarios(string id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuarios);
            db.SaveChanges();

            return Ok(usuarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuariosExists(string id)
        {
            return db.Usuarios.Count(e => e.Cedula == id) > 0;
        }
    }
}