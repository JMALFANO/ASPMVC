using CapaEntidades;
using CapaAccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    class admCategoria
    {

        dbCategoria obj = new dbCategoria();
        public void Agregar(Categoria categoria)
        {
            obj.Agregar(categoria);
        }
    }
}
