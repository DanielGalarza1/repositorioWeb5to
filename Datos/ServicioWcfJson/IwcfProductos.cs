using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;

namespace ServicioWcfJson
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IwcfProductos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IwcfProductos
    {
        [OperationContract]
        [WebGet(UriTemplate = "getProductos",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<Producto> DevolverTodosLosProductos();
    }
}
