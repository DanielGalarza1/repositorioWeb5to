using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFJson
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IwcfOperaciones" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IwcfOperaciones
    {
        [OperationContract]
        [WebGet(UriTemplate = "getPrimos100",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<int> ImprimirNumerosPrimosHasta100();

        /*[OperationContract]
        [WebGet(UriTemplate="getPrimos",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<int> ImprimirNumerosPrimos(int limite);

        [OperationContract]
        [WebGet(UriTemplate = "getPrimosLimite",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<int> ImprimirNumerosPrimosInicioFin(int inicio, int fin);*/
    }
}
