using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class ProductoNegocio
    {

        public static List<Producto> DevolverListaProductos()
        {
            return ProductoDatos.DevolverListaProductos();
        }

        public static List<Producto> DevolverListaProductosDescontinuados()
        {
            return ProductoDatos.DevolverListaProductos().Where(x=> x.Discontinued==true).ToList();
        }
        public static List<Producto> DevolverListaProductosConStockCero()
        {
            return ProductoDatos.DevolverListaProductos().Where(x => x.UnitsInStock == 0).ToList();
        }
        public static List<Producto> DevolverListaProductosConRiesgoCaducarse()
        {
            return ProductoDatos.DevolverListaProductos().Where(x => x.UnitsInStock >= 76).ToList();
        }
    }
}
