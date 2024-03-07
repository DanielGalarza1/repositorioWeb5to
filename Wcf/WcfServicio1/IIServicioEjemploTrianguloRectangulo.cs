using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServicio1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IIServicioEjemploTrianguloRectangulo" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IIServicioEjemploTrianguloRectangulo
    {
        [OperationContract]
        string Triangulo(double x1, double y1, double x2, double y2, double x3, double y3);
    }
}
