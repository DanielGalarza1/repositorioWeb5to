using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Servicio_1
{
    /// <summary>
    /// Descripción breve de WebServiceUsuarios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceUsuarios : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Usuario> Listado()
        {
            return DevolverListadoUsuario();
        }

        public List<Usuario> DevolverListadoUsuario()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            listaUsuarios.Add(new Usuario(1, "Hernan", "1801", "colombiana"));
            listaUsuarios.Add(new Usuario(2, "Daniel", "1801", "colombiana"));
            listaUsuarios.Add(new Usuario(3, "German", "1801", "colombiana"));
            listaUsuarios.Add(new Usuario(4, "Manuel", "1801", "colombiana"));
            listaUsuarios.Add(new Usuario(5, "Flan", "1801", "colombiana"));
           

            return listaUsuarios;
        }
    }
}
