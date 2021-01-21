using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.ListaPrecioProducto
{
    public class ListaPrecioProductoDto
    {
        public long Id { get; set; }
        public long ListaPrecioId { get; set; }
        public long ProductoId { get; set; }
        public string ProductoStr { get; set; }
        public string ListaPrecioStr { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PrecioPublico { get; set; }
        public decimal Alicuota { get; set; }
        public DateTime Fecha { get; set; }

    }
}
