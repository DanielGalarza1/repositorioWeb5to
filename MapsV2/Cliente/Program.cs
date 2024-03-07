using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.ServiceReference1;

namespace Cliente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.IwcfUbicacionesClient client = new ServiceReference1.IwcfUbicacionesClient();

            var ubicacion = new ServicioUbicacion.Ubicacion
            {
                IdNegocioCliente = 25,
                Nombre = "Daniel",
                Apellido = "Galarza",
                NombreNegocio = "El Rincón del Sabor",
                TipoNegocio = "Licoreria",
                Direccion = "Av. Los Pinos 321",
                Latitud = (decimal)-1.252888,
                Longitud = (decimal)-78.625999,
                Horario = "Lun-Dom: 11:00-22:00",
                Telefono = "+593 9 34567890",
                Descripcion = "Licorería con variedad de bebidas y ambiente acogedor."
            };

            var ubicacionCreada = client.CrearUbicacion(25, "Daniel", "Galarza", "El Rincón del Sabor", "Licoreria", "Av. Los Pinos 321", (decimal)-1.252888, (decimal)-78.625999, "Lun-Dom: 11:00-22:00", "+593 9 34567890", "Licorería con variedad de bebidas y ambiente acogedor.");

            Console.WriteLine("Ubicación creada: ");
            Console.ReadLine();
        }
    }
}
