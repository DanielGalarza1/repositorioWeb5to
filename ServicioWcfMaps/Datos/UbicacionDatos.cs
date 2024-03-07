using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Datos
{
    public static class UbicacionDatos
    {
        public static List<UbicacionEntidad> DevolverListaUbicaciones()
        {
			try
			{
				List<UbicacionEntidad> listaUbicacion = new List<UbicacionEntidad>();
				List<UBICACION> listaUbicacionLinq = new List<UBICACION>();
				using (var contexto = new DataClasses1DataContext()) 
				{
					var resultado = from p in contexto.UBICACION
									select p;
					listaUbicacionLinq = resultado.ToList();
				}

                foreach (var item in listaUbicacionLinq)
                {
					listaUbicacion.Add(new UbicacionEntidad(
						item.IdNegocioCliente,
						item.NombreCliente,
						item.ApellidoCliente,
						item.NombreNegocio,
						item.TipoNegocio,
						item.Direccion,
						(decimal)item.Latitud,
                        (decimal)item.Longitud,
						item.HorarioAtencion,
						item.Telefono,
						item.Descripcion
						));
                }
				return listaUbicacion;
            }
			catch (Exception)
			{
				throw;
			}
        }

        public static UbicacionEntidad Nuevo(UbicacionEntidad ubicacionEntidad)
        {
            try
            {
                UBICACION ubicacionLinq = new UBICACION();
                ubicacionLinq.IdNegocioCliente = ubicacionEntidad.IdNegocioCliente;
                ubicacionLinq.NombreCliente = ubicacionEntidad.Nombre;
                ubicacionLinq.ApellidoCliente = ubicacionEntidad.Apellido;
                ubicacionLinq.NombreNegocio = ubicacionEntidad.NombreNegocio;
                ubicacionLinq.TipoNegocio = ubicacionEntidad.TipoNegocio;
                ubicacionLinq.Direccion = ubicacionEntidad.Direccion;
                ubicacionLinq.Latitud = ubicacionEntidad.Latitud;
                ubicacionLinq.Longitud = ubicacionEntidad.Longitud;
                ubicacionLinq.HorarioAtencion = ubicacionEntidad.Horario;
                ubicacionLinq.Telefono = ubicacionEntidad.Telefono;
                ubicacionLinq.Descripcion = ubicacionEntidad.Descripcion;

                using (DataClasses1DataContext contexto = new DataClasses1DataContext())
                {
                    contexto.UBICACION.InsertOnSubmit(ubicacionLinq);
                    contexto.SubmitChanges();
                }
                ubicacionEntidad.IdNegocioCliente = ubicacionLinq.IdNegocioCliente;
                return ubicacionEntidad;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
