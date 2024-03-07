using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServicioWCF
{
    [DataContract]
    public class Ubicacion
    {
        [DataMember]
        public int IdNegocioCliente { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Apellido { get; set; }
        [DataMember]
        public string NombreNegocio { get; set; }
        [DataMember]
        public string TipoNegocio { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public decimal Latitud { get; set; }
        [DataMember]
        public decimal Longitud { get; set; }
        [DataMember]
        public string Horario { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Descripcion { get; set; }

        public Ubicacion()
        {

        }

        public Ubicacion(int idNegocioCliente, string nombre, string apellido, string nombreNegocio, string tipoNegocio, 
            string direccion, decimal latitud, decimal longitud, string horario, string telefono, string descripcion)
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

        public Ubicacion( string nombre, string apellido, string nombreNegocio, string tipoNegocio, string direccion,
            decimal latitud, decimal longitud, string horario, string telefono, string descripcion)
        {
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
    }
}