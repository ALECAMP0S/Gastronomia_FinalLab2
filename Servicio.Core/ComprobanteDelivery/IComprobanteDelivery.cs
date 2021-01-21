using Servicio.Core.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.ComprobanteDelivery
{
    public interface IComprobanteDelivery
    {
        void Crear(long clienteId, ComprobanteDeliveryDto dto);

        ComprobanteDeliveryDto ObtenerComprobantePorCliente(long clienteId);

        ComprobanteDeliveryDto ObtenerComprobantePorId(long comprobanteId);

        IEnumerable<ComprobanteDeliveryDto> ObtenerComprobantesPorCliente(long? clienteId);

        void AgregarItem(long comprobanteId, int cantidad, ProductoDto producto, long listaId);

        void EliminarItem(long comprobanteId, int cantidad, ProductoDto producto, long listaId);

        void QuitarComprobante(long clienteId);

        void ComprobanteCtaCte(long clienteId);

    }
}
