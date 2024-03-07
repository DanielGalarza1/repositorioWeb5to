using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Newtonsoft.Json;
using System.Web.Script.Services;

namespace SerciciosAsmxJason
{
    /// <summary>
    /// Descripción breve de wsUsuaruoJson
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsUsuaruoJson : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DevolverListadoCleintes()
        {
           Context.Response.Write(DevolverUsuarios());
        }

        private string DevolverUsuarios()
        {
            string respuesta = JsonConvert.SerializeObject(DevolverListadoUsuario());
            return respuesta;
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
