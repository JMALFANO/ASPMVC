using CapaAccesoADatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class admProducto
    {

        public List<Producto> Listar()
        {
            return new dbProducto().Listar();
        }

   
        /*
        public Categoria ObtenerPorId(int categoriaId)
        {
            return new dbCategoria().ObtenerPorId(categoriaId);
        }*/

        public void Guardar(Producto producto)
        {
            if (producto.Id != null)
                new dbProducto().Modificar(producto);
            else
                new dbProducto().Insertar(producto);

        }

    }
}
