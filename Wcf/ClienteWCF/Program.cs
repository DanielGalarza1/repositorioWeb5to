using System;
using System.ServiceModel;
using ClienteWCF.proxyServiciosEjemplos;

namespace ClienteWCF
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                IServicioEjemplosWfcClient client = new IServicioEjemplosWfcClient();
                var limite = 50;
                var lista = client.GenerarNumerosPares(limite);
                foreach (var item in lista)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }
			catch (EndpointNotFoundException e)
			{
                Console.WriteLine(e.Message);
                Console.WriteLine("El servicio no esta levantado");
                Console.Read();
			}
        }
    }
}
