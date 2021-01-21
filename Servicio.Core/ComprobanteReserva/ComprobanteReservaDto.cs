using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.ComprobanteReserva
{
    public class ComprobanteReservaDto
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public DateTime FechaReserva { get; set; }
        public int CantidadComensales { get; set; }
        public decimal MontoSenia { get; set; }
        public EstadoReserva EstadoReserva { get; set; } // este no, ok xD si una nueva q? si :v
        public long EmpleadoId { get; set; }
        public string Observacion { get; set; }

    }
}
