using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoADatos;
using CapaEntidades;

namespace CapaNegocio
{
   public class admBodega
    {
        public List<Bodega> Listar()
        {
            return new dbBodega().Listar();
        }

        public List<Bodega> ListarBodega()
        {
            return new dbBodega().ListarBodega();
        }

        
        public Bodega ObtenerPorId(int id)
        {
            return new dbBodega().ObtenerPorId(id);
        }

        public void Guardar(Bodega bodega)
        {
            if (bodega.Id != null)
                new dbBodega().Modificar(bodega);
            else
                new dbBodega().Insertar(bodega);

        }

        public void Eliminar(int Id)
        {
            new dbBodega().Delete(Id);
        }

    }
}
