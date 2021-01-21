using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.ComprobanteDelivery
{
    public class ComprobanteDeliveryDto
    {
        public ComprobanteDeliveryDto()
        {
            ComprobanteDeliveryDetalleDtos = new List<ComprobanteDeliveryDetalleDto>();
        }

        public long Id { get; set; }
        public long ClienteId { get; set; }
        public long CadeteId { get; set; }

        public string Cadete { get; set; }
        public string Cliente { get; set; }

        public string Direccion { get; set; }

        public decimal Total { get; set; }

        public List<ComprobanteDeliveryDetalleDto> ComprobanteDeliveryDetalleDtos { get; set; }
    }
}
