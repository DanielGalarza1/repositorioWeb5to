using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Web;

namespace ServicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "wcfUbicaciones" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione wcfUbicaciones.svc o wcfUbicaciones.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class wcfUbicaciones : IwcfUbicaciones
    {
        public List<UbicacionEntidad> DevolverUbicaciones()
        {
            return UbicacionNegocio.DevolverListaUbicaciones();
        }

        public List<UbicacionEntidad> ObtenerUbicacionPorId(string id)
        {
            return UbicacionNegocio.DevolverListaUbicacionId(id);
        }

        public Ubicacion CrearUbicacion(int idNegocioCliente, string nombre, string apellido, string nombreNegocio,
            string tipoNegocio, string direccion, decimal latitud, decimal longitud, string horario, string telefono, string descripcion)
        {
            Ubicacion ubicacion = new Ubicacion(idNegocioCliente, nombre, apellido, nombreNegocio, tipoNegocio, 
                direccion, latitud, longitud, horario, telefono, descripcion);
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexionBD);
                conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO [dbo].[UBICACION]
                                   ([IdNegocioCliente]
                                   ,[NombreCliente]
                                   ,[ApellidoCliente]
                                   ,[NombreNegocio]
                                   ,[TipoNegocio]
                                   ,[Direccion]
                                   ,[Latitud]
                                   ,[Longitud]
                                   ,[HorarioAtencion]
                                   ,[Telefono]
                                   ,[Descripcion])
                                 VALUES(@idNegocioCliente, @nombreCliente, @apellidoCliente, @nombreNegocio, @tipoNegocio,
                                                @direccion, @latitud, @longitud,@horarioAtencion,@telefono,@descripcion);";
                cmd.Parameters.AddWithValue("@idNegocioCliente", ubicacion.IdNegocioCliente);
                cmd.Parameters.AddWithValue("@nombreCliente", ubicacion.Nombre);
                cmd.Parameters.AddWithValue("@apellidoCliente", ubicacion.Apellido);
                cmd.Parameters.AddWithValue("@nombreNegocio", ubicacion.NombreNegocio);
                cmd.Parameters.AddWithValue("@tipoNegocio", ubicacion.TipoNegocio);
                cmd.Parameters.AddWithValue("@direccion", ubicacion.Direccion);
                cmd.Parameters.AddWithValue("@latitud", ubicacion.Latitud);
                cmd.Parameters.AddWithValue("@longitud", ubicacion.Longitud);
                cmd.Parameters.AddWithValue("@horarioAtencion", ubicacion.Horario);
                cmd.Parameters.AddWithValue("@telefono", ubicacion.Telefono);
                cmd.Parameters.AddWithValue("@descripcion", ubicacion.Descripcion);

                cmd.ExecuteNonQuery();
                conexion.Close();
                return ubicacion;

            }
            catch (Exception e)
            {
                var error = e.Message;
                throw;
            }
        }

        public Ubicacion ActualizarUbicacion(string id, string nombre, string apellido, string nombreNegocio, string tipoNegocio, 
            string direccion, decimal latitud, decimal longitud, string horario, string telefono, string descripcion)
        {
            try
            {
                Ubicacion ubicacion = new Ubicacion(nombre, apellido, nombreNegocio, tipoNegocio, 
                    direccion, latitud, longitud, horario, telefono, descripcion);

                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexionBD);
                conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE [dbo].[UBICACION]
                                   SET [NombreCliente] =  @nombreCliente
                                      ,[ApellidoCliente] =  @apellidoCliente
                                      ,[NombreNegocio] =  @nombreNegocio
                                      ,[TipoNegocio] =  @tipoNegocio
                                      ,[Direccion] = @direccion
                                      ,[Latitud] =  @latitud
                                      ,[Longitud] = @longitud
                                      ,[HorarioAtencion] = @horarioAtencion
                                      ,[Telefono] = @telefono
                                      ,[Descripcion] = @descripcion
                                 WHERE IdNegocioCliente = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombreCliente", ubicacion.Nombre);
                cmd.Parameters.AddWithValue("@apellidoCliente", ubicacion.Apellido);
                cmd.Parameters.AddWithValue("@nombreNegocio", ubicacion.NombreNegocio);
                cmd.Parameters.AddWithValue("@tipoNegocio", ubicacion.TipoNegocio);
                cmd.Parameters.AddWithValue("@direccion", ubicacion.Direccion);
                cmd.Parameters.AddWithValue("@latitud", ubicacion.Latitud);
                cmd.Parameters.AddWithValue("@longitud", ubicacion.Longitud);
                cmd.Parameters.AddWithValue("@horarioAtencion", ubicacion.Horario);
                cmd.Parameters.AddWithValue("@telefono", ubicacion.Telefono);
                cmd.Parameters.AddWithValue("@descripcion", ubicacion.Descripcion);

                cmd.ExecuteNonQuery();
                conexion.Close();
                return ubicacion;

            }
            catch (Exception e)
            {
                var error = e.Message;
                throw;
            }
        }

        public bool EliminarUbicacion(string id)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexionBD);
                conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"DELETE FROM [dbo].[UBICACION]
                                          WHERE IdNegocioCliente = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conexion.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}

