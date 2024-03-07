using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServicio1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "IServicioEjemplosWfc" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione IServicioEjemplosWfc.svc o IServicioEjemplosWfc.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class IServicioEjemplosWfc : IIServicioEjemplosWfc
    {

        public List<int> GenerarNumerosPares(int limite)
        {
            List<int> listaResultado = new List<int>();
            for (int i = 2; i <= limite; i+=2) { 
                listaResultado.Add(i);
            }
            return listaResultado;
        }

        public double Potencia(double _base, double _exponente)
        {
            return Math.Pow(_base, _exponente);
        }

        public double RaizCuadrada(double numero)
        {
            return Math.Sqrt(numero);
        }

        public string Saludo()
        {
            return "Saludos desde el Servicio WCF";
        }
    }
}
