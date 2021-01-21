using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.Producto
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string CodigoBarra { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioPublico { get; set; }
        public long SubRubroId { get; set; }
        public long MarcaId { get; set; }
        public decimal Stock { get; set; }
        public DateTime FechaActualizacion { get; set; }

    }
}
