using DAL;

namespace Servicio.Core.Mesa
{
    public class MesaDto
    {
        public long Id { get; set; }
        public int Numero { get; set; }
        public string Descripcion { get; set; }
        public EstadoMesa EstadoMesa { get; set; }
        // Comprobantes
        public decimal Total => SalonMesa.SaloMesaServicio.ObtenerTotalVenta(Id);
        public long ComprobanteId { get; set; }
    }
}