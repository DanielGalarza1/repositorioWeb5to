using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClienteServicio.ProxyServicioTest1;

namespace ClienteServicio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebServiceTest1SoapClient ws = new WebServiceTest1SoapClient();
            Console.WriteLine(ws.SaludosMatutinos());
            double x = 5 , y = 4;
            Console.WriteLine(ws.Potencia(x, y));

            Console.ReadLine();
        }
    }
}
