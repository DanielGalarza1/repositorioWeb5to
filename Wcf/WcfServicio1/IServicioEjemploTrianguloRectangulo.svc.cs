using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServicio1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "IServicioEjemploTrianguloRectangulo" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione IServicioEjemploTrianguloRectangulo.svc o IServicioEjemploTrianguloRectangulo.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class IServicioEjemploTrianguloRectangulo : IIServicioEjemploTrianguloRectangulo
    {
        public string Triangulo(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            // Calcular las longitudes de los lados del triángulo
            double lado1 = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            double lado2 = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            double lado3 = Math.Sqrt(Math.Pow(x1 - x3, 2) + Math.Pow(y1 - y3, 2));

            // Comprobar los tipos de triángulo
            if (lado1 == lado2 && lado2 == lado3)
            {
                return "Equilátero";
            }
            else if (lado1 == lado2 || lado1 == lado3 || lado2 == lado3)
            {
                return "Isósceles";
            }
            else
            {
                return "Escaleno";
            }
        }
    }
}
