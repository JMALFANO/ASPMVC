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
        
        public Producto ObtenerPorId(int id)
        {
            return new dbProducto().ObtenerPorId(id);
        }

        public void Guardar(Producto producto)
        {
            if (producto.Id != null)
                new dbProducto().Modificar(producto);
            else
                new dbProducto().Insertar(producto);

        }

        public void Eliminar(int Id)
        {
            new dbProducto().Delete(Id);
        }


    }
}
