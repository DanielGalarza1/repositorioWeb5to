using Negocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Newtonsoft.Json;
using System.Web.Script.Services;

namespace Servicio
{
    /// <summary>
    /// Descripción breve de wsProductos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsProductos : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DevolverTodosLosProductos()
        {
            Context.Response.Write(DevolverProducto());
        }

        private string DevolverProducto()
        {
            string respuesta = JsonConvert.SerializeObject(ProductoNegocio.DevolverListaProductos());
            return respuesta;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DevolverTodosLosProductosConStockCero()
        {
            Context.Response.Write(DevolverProductoConStockCero());
        }

        private string DevolverProductoConStockCero()
        {
            string respuesta = JsonConvert.SerializeObject(ProductoNegocio.DevolverListaProductosConStockCero());
            return respuesta;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DevolverTodosLosProductosDescontinuados()
        {
            Context.Response.Write(DevolverProductoProductosDescontinuados());
        }

        private string DevolverProductoProductosDescontinuados()
        {
            string respuesta = JsonConvert.SerializeObject(ProductoNegocio.DevolverListaProductosDescontinuados());
            return respuesta;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DevolverTodosLosProductosConRiesgoCaducarse()
        {
            Context.Response.Write(DevolverProductoConRiesgoCaducarse());
        }

        private string DevolverProductoConRiesgoCaducarse()
        {
            string respuesta = JsonConvert.SerializeObject(ProductoNegocio.DevolverListaProductosConRiesgoCaducarse());
            return respuesta;
        }
    }
}
