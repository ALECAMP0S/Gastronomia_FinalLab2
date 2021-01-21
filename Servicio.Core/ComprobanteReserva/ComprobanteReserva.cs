using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.ComprobanteReserva
{
    public class ComprobanteReserva : IComprobanteReserva
    {
        public void Crear(long mesaId,ComprobanteReservaDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var nuevoComprobane = new Reserva
                {
                    Fecha = DateTime.Now,
                    ClienteId = dto.ClienteId,
                    CantidadComensales = dto.CantidadComensales,
                    EmpleadoId = dto.EmpleadoId,
                    EstadoReserva = EstadoReserva.Reservado,
                    FechaReserva = dto.FechaReserva,
                    MontoSenia = dto.MontoSenia,
                    Observacion = dto.Observacion,
                    TipoComprobante = TipoComprobante.Impaga
                    
                };

                context.Comprobantes.Add(nuevoComprobane);
                context.SaveChanges();
            }
        }
        public ComprobanteReservaDto ObtenerComprobantePorCliente(long clienteId)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var comprobante = context.Comprobantes.OfType<Reserva>()
                    .Include("Empleado")
                    .Include("Cliente")
                    .FirstOrDefault(x => x.ClienteId == clienteId
                                         && x.EstadoReserva == EstadoReserva.Reservado);

                if (comprobante == null) throw new ArgumentNullException("Error Grave");

                var comprobanteDto = new ComprobanteReservaDto
                {
                    Id = comprobante.Id,
                    ClienteId = comprobante.ClienteId,
                    EmpleadoId = comprobante.EmpleadoId,
                    FechaReserva = comprobante.FechaReserva,
                    CantidadComensales = comprobante.CantidadComensales,
                    MontoSenia = comprobante.MontoSenia,
                    EstadoReserva = comprobante.EstadoReserva,
                    Observacion = comprobante.Observacion

                };


                return comprobanteDto;
            }
        }
        public void QuitarComprobante(long comprobanteId)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var quitarComprobante = context.Comprobantes.OfType<Reserva>()
                    .Include("Empleado")
                    .Include("Cliente")
                    .FirstOrDefault(x => x.Id == comprobanteId
                    && x.EstadoReserva == EstadoReserva.Reservado);


                quitarComprobante.EstadoReserva = EstadoReserva.Confirmado;
                quitarComprobante.TipoComprobante = TipoComprobante.Pagada;

                context.SaveChanges();

            }
        }



    }
}
