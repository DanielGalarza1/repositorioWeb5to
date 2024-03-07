using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFJson
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "wcfOperaciones" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione wcfOperaciones.svc o wcfOperaciones.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class wcfOperaciones : IwcfOperaciones
    {
        public void DoWork()
        {
        }

        public List<int> ImprimirNumerosPrimos(int limite)
        {
            List<int> listaResultado = new List<int>(); 
            for (int i = 2; i < limite; i++)
            {
                if (ValidarPrimo(i))
                {
                    listaResultado.Add(i);
                }
            }
            return listaResultado;  
        }

        public List<int> ImprimirNumerosPrimosHasta100()
        {
            List<int> listaResultado = new List<int>();
            for (int i = 2; i < 100; i++)
            {
                if (ValidarPrimo(i))
                {
                    listaResultado.Add(i);
                }
            }
            return listaResultado;
        }

        public List<int> ImprimirNumerosPrimosInicioFin(int inicio, int fin)
        {
            List<int> listaResultado = new List<int>();
            for (int i = inicio; i < fin; i++)
            {
                if (ValidarPrimo(i))
                {
                    listaResultado.Add(i);
                }
            }
            return listaResultado;
        }

        bool ValidarPrimo(int numero)
        {
            for (int i = 2; i < numero; i++)
            {
                if (numero % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
