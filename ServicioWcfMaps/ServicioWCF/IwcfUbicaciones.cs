using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;

namespace ServicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IwcfUbicaciones" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IwcfUbicaciones
    {
        [OperationContract]
        [WebGet(UriTemplate = "getUbicaciones",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<UbicacionEntidad> DevolverUbicaciones();

        [OperationContract]
        [WebGet(UriTemplate = "getUbicaciones/{id}",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        List<UbicacionEntidad> ObtenerUbicacionPorId(string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
        BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, UriTemplate = "postUbicaciones")]
        Ubicacion CrearUbicacion(int idNegocioCliente, string nombre, string apellido, string nombreNegocio, 
            string tipoNegocio, string direccion, decimal latitud, decimal longitud, string horario, string telefono, string descripcion);

        [OperationContract]
        [WebInvoke(Method = "PUT",
        BodyStyle = WebMessageBodyStyle.WrappedRequest,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "putUbicaciones/{id}")]
        Ubicacion ActualizarUbicacion(string id, string nombre, string apellido, string nombreNegocio, string tipoNegocio,
            string direccion, decimal latitud, decimal longitud, string horario, string telefono, string descripcion);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "eliminarUbicacion/{id}")]
        bool EliminarUbicacion(string id);
    }
}