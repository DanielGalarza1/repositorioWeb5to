using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public static class ProductoDatos
    {
        public static List<Producto> DevolverListaProductos()
        {
            try
            {
                List<Producto> listaProductos = new List<Producto>();
                List<Products> listaProductosLINQ = new List<Products>();
                using (var contexto = new DataClasses1DataContext())
                {
                    var resultado = from p in contexto.Products
                                    select p;
                    listaProductosLINQ = resultado.ToList();
                }
                foreach (var item in listaProductosLINQ)
                {
                    listaProductos.Add(new Producto(
                            item.ProductID,
                            item.ProductName,
                            item.QuantityPerUnit,
                            (decimal)item.UnitPrice,
                            (int)item.UnitsInStock,
                            item.Discontinued
                          ));
                }

                return listaProductos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
