using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Entidad;
using Negocio;

namespace Servicios
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
        public List<Producto> DevolverTodosLosProductos()
        {
            return ProductoNegocio.DevolverListaProductos();
        }


        [WebMethod]
        public List<Producto> DevolverTodosLosProductosConStockCero()
        {
            return ProductoNegocio.DevolverListaProductosConStockCero();
        }


        [WebMethod]
        public List<Producto> DevolverTodosLosProductosDescontinuados()
        {
            return ProductoNegocio.DevolverListaProductosDescontinuados();
        }


        [WebMethod]
        public List<Producto> DevolverTodosLosProductosConRiesgoCaducarse()
        {
            return ProductoNegocio.DevolverListaProductosConRiesgoCaducarse();
        }
    }
}
