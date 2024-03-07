using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicioUbicacion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public string CrearUbicacion(Ubicacion ubicacion)
        {
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

                conexion.Close();
                return "Ubicacion Creada con eexito";

            }
            catch (Exception e)
            {
                var error = e.Message;
                throw;
            }
        }

        public Ubicacion CrearUbicacion(int idNegocioCliente, string nombre, string apellido, string nombreNegocio, string tipoNegocio, string direccion, decimal latitud, decimal longitud, string horario, string telefono, string descripcion)
        {
            Ubicacion ubicacion = new Ubicacion(idNegocioCliente, nombre, apellido, nombreNegocio, tipoNegocio, direccion, latitud, longitud, horario, telefono, descripcion);
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
                cmd.Parameters.AddWithValue("@descripcion", ubicacion.Direccion);

                conexion.Close();
                return ubicacion;

            }
            catch (Exception e)
            {
                var error = e.Message;
                throw;
            }
        }
    }
}
