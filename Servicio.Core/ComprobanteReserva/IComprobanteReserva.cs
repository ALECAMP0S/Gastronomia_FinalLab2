using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.ComprobanteReserva
{
    public interface IComprobanteReserva
    {
        void Crear(long mesaId, ComprobanteReservaDto dto);

        ComprobanteReservaDto ObtenerComprobantePorCliente(long clienteId);
        //ComprobanteSalonDto ObtenerComprobantePorMesa(long mesaId);

        //void AgregarItem(long comprobanteId, int cantidad, ProductoDto producto, long listaId);

        //void EliminarItem(long comprobanteId, int cantidad, ProductoDto producto, long listaId);

        void QuitarComprobante(long comprobanteId);
    }
}
