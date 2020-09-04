using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
   public class Bodega
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public Producto producto { get; set; }
        public int CantidadProducto { get; set; } 
    }
}
