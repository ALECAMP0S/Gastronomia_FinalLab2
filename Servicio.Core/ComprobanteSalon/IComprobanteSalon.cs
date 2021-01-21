using Servicio.Core.Producto;
using System.Collections.Generic;

namespace Servicio.Core.ComprobanteSalon
{
    public interface IComprobanteSalon
    {
        void Crear(long mesaId, long? clienteId);

        void CambiarMesa(long mesaId, long nuevaMesa);

        ComprobanteSalonDto ObtenerComprobantePorMesa(long mesaId);

        ComprobanteSalonDto ObtenerComprobantePorId(long comprobanteId);

        IEnumerable<ComprobanteSalonDto> ObtenerComprobantesPorCliente(long? clienteId);

        void AgregarItem(long comprobanteId, int cantidad, ProductoDto producto,long listaId);

        void EliminarItem(long comprobanteId, int cantidad, ProductoDto producto,long listaId);

        void DisminuirCantidadItem(long comprobanteId, ProductoDto producto, int cantidad);

        void QuitarComprobante(long mesaId);

        void ComprobanteCtaCte(long mesaId);

        void AgregarCliente(long mesaId, long? clienteId);


    }
}
