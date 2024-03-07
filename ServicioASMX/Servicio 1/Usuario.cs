using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio_1
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Nacionalidad { get; set; }
        
        public Usuario() { }

        public Usuario(int id, string nombre, string cedula, string nacionalidad)
        {
            Id = id;
            Nombre = nombre;
            Cedula = cedula;    
            Nacionalidad = nacionalidad;
        }

    }
}