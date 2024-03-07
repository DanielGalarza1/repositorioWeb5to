using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Servicio_1
{
    /// <summary>
    /// Descripción breve de WebServiceTest1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceTest1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string SaludosMatutinos()
        {
            return "Buenos dias futuros Ingenieros";
        }

        [WebMethod]
        public double SumarDosNumeros(double numero1, double numero2)
        { 
            return numero1+numero2;
        }

        [WebMethod]
        public double Potencia(double _base, double _exponente)
        {
            return Math.Pow(_base, _exponente);
        }

        [WebMethod]
        public int LanzamientoDado()
        {
            Random nun = new Random();
            int resultado = nun.Next(1, 7);
            return resultado;
        }

        [WebMethod]
        public string JuegoDado()
        {
            Random nun = new Random();
            int resultado = nun.Next(1, 7);
            int resultado2 = nun.Next(1, 7);
            if (resultado == resultado2)
            {
                return "Ganador le salio dobles: " + resultado +" , "+ resultado2;
            }
            else {
                return "Perdedor : " + resultado + " , " + resultado2;
            }
        }

    }
}
