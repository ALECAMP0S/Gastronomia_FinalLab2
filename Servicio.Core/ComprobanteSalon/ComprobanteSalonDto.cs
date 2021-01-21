using System.Collections.Generic;

namespace Servicio.Core.ComprobanteSalon
{
    public class ComprobanteSalonDto
    {
        public ComprobanteSalonDto()
        {
            ComprobanteSalonDetalleDtos = new List<ComprobanteSalonDetalleDto>();
        }

        public long Id { get; set; }
        public long MesaId { get; set; }
        public long? MozoId { get; set; }

        public string Mozo { get; set; }

        public decimal Total { get; set; }

        public long? ClienteId { get; set; }

        public List<ComprobanteSalonDetalleDto> ComprobanteSalonDetalleDtos { get; set; }
    }
}
