using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Producto
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Categoria { get; set; }
        public int Bodega { get; set; }
        public float Precio { get; set; }

        public int UnidadesProducto { get; set; }

    }
}
