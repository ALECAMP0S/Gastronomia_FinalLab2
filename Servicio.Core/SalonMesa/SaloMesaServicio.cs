using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL;
using Servicio.Core.Mesa;

namespace Servicio.Core.SalonMesa
{
    public class SaloMesaServicio : ISaloMesaServicio
    {
        public IEnumerable<MesaDto> ObtenerMesasParaSalon()
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                return context.Mesas.AsNoTracking()
                    .Include("Salones")
                    .Include("Salones.DetallesSalones")
                    .Select(x => new MesaDto()
                     {
                         Id = x.Id,
                         Numero = x.Numero,
                         Descripcion = x.Descripcion,
                         EstadoMesa = x.EstadoMesa,
                         ComprobanteId = x.Salones.Any(s => s.EstadoSalon == EstadoSalon.Pendiente)
                           ? x.Salones
                               .FirstOrDefault(s => s.EstadoSalon == EstadoSalon.Pendiente).Id
                               : -1
                    }).ToList();
            }
        }

        public static decimal ObtenerTotalVenta(long mesaId)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var comprobante = context.Comprobantes.OfType<Salon>()
                    .Include("DetallesSalones")
                    .FirstOrDefault(x => x.MesaId == mesaId 
                    && x.EstadoSalon == EstadoSalon.Pendiente);

                if (comprobante == null) return 0m;

                if (comprobante.DetallesSalones == null) return 0m;

                if (comprobante.DetallesSalones.Any())
                    return comprobante.DetallesSalones.Sum(x => x.SubTotal);

                return 0m;
            }
        }
    }
}
