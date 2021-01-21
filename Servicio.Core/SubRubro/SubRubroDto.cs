using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.SubRubro
{
    public class SubRubroDto
    {
        public long Id { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public long RubroId { get; set; }
    }
}
