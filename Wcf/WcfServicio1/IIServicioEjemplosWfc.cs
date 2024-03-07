using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServicio1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IIServicioEjemplosWfc" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IIServicioEjemplosWfc
    {
        [OperationContract]
        string Saludo();

        [OperationContract]
        double Potencia(double _base, double _exponente);

        [OperationContract]
        double RaizCuadrada(double numero);

        [OperationContract]
        List<int> GenerarNumerosPares(int limite);
    }
}
