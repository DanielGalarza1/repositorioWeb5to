using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class UbicacionEntidad
    {
        public UbicacionEntidad(int idNegocioCliente, string nombre, string apellido, string nombreNegocio, string tipoNegocio, string direccion, decimal latitud, decimal longitud, string horario, string telefono, string descripcion)
        {
            IdNegocioCliente = idNegocioCliente;
            Nombre = nombre;
            Apellido = apellido;
            NombreNegocio = nombreNegocio;
            TipoNegocio = tipoNegocio;
            Direccion = direccion;
            Latitud = latitud;
            Longitud = longitud;
            Horario = horario;
            Telefono = telefono;
            Descripcion = descripcion;
        }

        public UbicacionEntidad()
        {
            
        }

        public int IdNegocioCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreNegocio { get; set; }
        public string TipoNegocio { get; set; }
        public string Direccion { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string Horario { get; set; }
        public string Telefono { get; set; }
        public string Descripcion { get; set; }
    }
}
