using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicioUbicacion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest,
        ResponseFormat = WebMessageFormat.Json, UriTemplate = "postUbicaciones")]
        Ubicacion CrearUbicacion(int idNegocioCliente, string nombre, string apellido, string nombreNegocio, string tipoNegocio, string direccion, decimal latitud, decimal longitud, string horario, string telefono, string descripcion);

        // TODO: agregue aquí sus operaciones de servicio
    }
}
