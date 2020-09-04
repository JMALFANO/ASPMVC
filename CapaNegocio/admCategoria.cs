using CapaEntidades;
using CapaAccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class admCategoria
    {

        public List<Categoria> Listar()
        {
            return new dbCategoria().Listar();
        }

        public List<Categoria> ListarCategoria()
        {
            return new dbCategoria().ListarCategoria();
        }



        /*
        public Categoria ObtenerPorId(int categoriaId)
        {
            return new dbCategoria().ObtenerPorId(categoriaId);
        }*/

        public void Guardar(Categoria categoria)
        {
            if (categoria.Id != null)
                new dbCategoria().Modificar(categoria);
            else
                new dbCategoria().Insertar(categoria);

        }

    }
}
