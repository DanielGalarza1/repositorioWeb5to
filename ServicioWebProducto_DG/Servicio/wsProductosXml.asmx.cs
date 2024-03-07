using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;


using Newtonsoft.Json;
using System.Web.Script.Services;
using Negocio;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Entidades;
using System.Runtime.Remoting.Contexts;

namespace Servicio
{
    /// <summary>
    /// Descripción breve de wsProductosXml
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsProductosXml : System.Web.Services.WebService
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

