using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;

namespace Negocio
{
    public static class UbicacionNegocio
    {
        public static List<UbicacionEntidad> DevolverListaUbicaciones() 
        { 
            return UbicacionDatos.DevolverListaUbicaciones();
        }

        public static List<UbicacionEntidad> DevolverListaUbicacionId(string id)
        {
            return UbicacionDatos.DevolverListaUbicaciones().Where(x => x.IdNegocioCliente == Int32.Parse(id)).ToList();
        }

        public static UbicacionEntidad Guardar(UbicacionEntidad ubicacionEntidad)
        {
                return UbicacionDatos.Nuevo(ubicacionEntidad);
        }
    }
}
