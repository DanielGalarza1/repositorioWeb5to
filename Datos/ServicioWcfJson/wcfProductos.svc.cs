using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioWcfJson
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "wcfProductos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione wcfProductos.svc o wcfProductos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class wcfProductos : IwcfProductos
    {
        public List<Producto> DevolverTodosLosProductos()
        {
            return ProductoNegocio.DevolverListaProductos();
        }

        public void DoWork()
        {
        }
    }
}
