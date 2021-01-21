using System;
using System.Data.Entity;
using System.Linq;
using DAL;
using Servicio.Core.Producto;
using System.Collections.Generic;

namespace Servicio.Core.ComprobanteSalon
{
    public class ComprobanteSalon : IComprobanteSalon
    {
        public void AgregarItem(long comprobanteId,int cantidad , ProductoDto producto, long listaId)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var comprobante = context.Comprobantes.OfType<Salon>()
                    .Include(x=> x.DetallesSalones)
                    .FirstOrDefault(x => x.Id == comprobanteId);

                if (comprobante== null)throw new Exception("Error");
                if (producto != null)
                {
                    var item = comprobante.DetallesSalones
                            .FirstOrDefault(x => x.ProductoId == producto.Id
                                                 && x.Precio == producto.PrecioPublico
                                                 && x.Producto.ListasPreciosProductos.Any(l => l.ListaPrecioId == listaId));
                        // error????

                    if (item != null)
                    {
                        //El caso de que si exista el producto en el Detalle
                        if (item.Precio == producto.PrecioPublico) // Por lista de Precios Distintas
                        {
                            item.Cantidad += cantidad;
                            item.SubTotal = item.Cantidad*producto.PrecioPublico;
                            producto.Stock -= 1;
                            comprobante.Total = item.Cantidad * producto.PrecioPublico;
                        }
                        else
                        {
                            CargarNuevoItem(cantidad, producto, comprobante);
                        }


                    }
                    else
                    {
                        CargarNuevoItem(cantidad, producto, comprobante);
                    }
                    context.SaveChanges();
                }
            }
        }

        private static void CargarNuevoItem(int cantidad, ProductoDto producto, Salon comprobante)
        {
            // En caso de que no exista el producto en el Detalle
            comprobante.DetallesSalones.Add(new DetalleSalon
            {
                Cantidad = cantidad,
                Codigo = producto.Codigo.ToString(),
                CodigoBarra = producto.CodigoBarra,
                Descripcion = producto.Descripcion,
                Precio = producto.PrecioPublico,
                ProductoId = producto.Id,
                SubTotal = producto.PrecioPublico*cantidad
                
            });
            comprobante.Total = producto.PrecioPublico * cantidad;

        }

        public void Crear(long mesaId, long? clienteId)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var nuevoComprobane = new Salon
                {
                    Fecha = DateTime.Now,
                    EstadoSalon = EstadoSalon.Pendiente,
                    MesaId = mesaId,
                    Descuento = 0m,
                    Subtotal = 0m,
                    Total = 0m,
                    Cubiertos = 1,
                    MozoId = null,
                    ClienteId = clienteId,
                };

                context.Comprobantes.Add(nuevoComprobane);
                context.SaveChanges();
            }
        }

        public void QuitarComprobante(long mesaId)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var quitarComprobante = context.Comprobantes.OfType<Salon>()
                    .Include("DetallesSalones")
                    .Include("Mozo")
                    .FirstOrDefault(x => x.MesaId == mesaId
                    && x.EstadoSalon == EstadoSalon.Pendiente);

                quitarComprobante.EstadoSalon = EstadoSalon.Facturado;
                quitarComprobante.TipoComprobante = TipoComprobante.Pagada;

                context.SaveChanges();

            }
        }
        public void ComprobanteCtaCte(long mesaId)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var quitarComprobante = context.Comprobantes.OfType<Salon>()
                    .Include("DetallesSalones")
                    .Include("Mozo")
                    .FirstOrDefault(x => x.MesaId == mesaId
                    && x.EstadoSalon == EstadoSalon.Pendiente);

                quitarComprobante.EstadoSalon = EstadoSalon.Pendiente;
                quitarComprobante.TipoComprobante = TipoComprobante.Impaga;

                context.SaveChanges();

            }
        }
        public void AgregarCliente(long mesaId, long? clienteId)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var quitarComprobante = context.Comprobantes.OfType<Salon>()
                    .Include("DetallesSalones")
                    .Include("Mozo")
                    .FirstOrDefault(x => x.MesaId == mesaId
                    && x.EstadoSalon == EstadoSalon.Pendiente);

                quitarComprobante.ClienteId = clienteId;

                context.SaveChanges();

            }
        }
        public void CambiarMesa(long mesaId, long nuevaMesa)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var cambiarComprobante = context.Comprobantes.OfType<Salon>()
                    .Include("DetallesSalones")
                    .Include("Mozo")
                    .FirstOrDefault(x => x.MesaId == mesaId
                    && x.EstadoSalon == EstadoSalon.Pendiente);

                cambiarComprobante.MesaId = nuevaMesa;

                context.SaveChanges();

            }
        }
        public ComprobanteSalonDto ObtenerComprobantePorMesa(long mesaId)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var comprobante = context.Comprobantes.OfType<Salon>()
                    .Include("DetallesSalones")
                    .Include("Mozo")
                    .FirstOrDefault(x => x.MesaId == mesaId
                                         && x.EstadoSalon == EstadoSalon.Pendiente
                                         && x.EstadoSalon != EstadoSalon.Facturado);
                if (comprobante== null)
                {
                    return null;
                }
               // if(comprobante == null) throw new ArgumentNullException("Error Grave");

                var comprobanteDto = new ComprobanteSalonDto
                {
                    Id = comprobante.Id,
                    Total = comprobante.Total,
                    MesaId = comprobante.MesaId,
                    MozoId = comprobante.MozoId,
                    Mozo = comprobante.MozoId.HasValue ? $"{comprobante.Mozo.Apellido} {comprobante.Mozo.Nombre}" : "No Asignado",
                    ClienteId = comprobante.ClienteId

                };

                if (comprobante.DetallesSalones != null
                    && comprobante.DetallesSalones.Any())
                {
                    foreach (var detalle in comprobante.DetallesSalones)
                    {
                        comprobanteDto.ComprobanteSalonDetalleDtos.Add(new ComprobanteSalonDetalleDto
                        {
                            Id = detalle.Id,
                            Descripcion = detalle.Descripcion,
                            Codigo = detalle.Codigo,
                            Cantidad = detalle.Cantidad,
                            SubTotal = detalle.SubTotal,
                            CodigoBarra = detalle.CodigoBarra,
                            ComprobanteSalonId = detalle.SalonId,
                            Precio = detalle.Precio,
                            ProductoId = detalle.ProductoId
                        });
                    }
                }

                return comprobanteDto;
            }
        }
        public ComprobanteSalonDto ObtenerComprobantePorId(long comprobanteId)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var comprobante = context.Comprobantes.OfType<Salon>()
                    .Include("DetallesSalones")
                    .Include("Mozo")
                    .FirstOrDefault(x => x.Id == comprobanteId
                                         && x.EstadoSalon == EstadoSalon.Facturado
                                         && x.EstadoSalon != EstadoSalon.Pendiente
                                         && x.TipoComprobante == TipoComprobante.Impaga);


                var comprobanteDto = new ComprobanteSalonDto
                {
                    Id = comprobante.Id,
                    Total = comprobante.Total,
                    MesaId = comprobante.MesaId,
                    MozoId = comprobante.MozoId,
                    Mozo = comprobante.MozoId.HasValue ? $"{comprobante.Mozo.Apellido} {comprobante.Mozo.Nombre}" : "No Asignado",
                    ClienteId = comprobante.ClienteId

                };

                if (comprobante.DetallesSalones != null
                    && comprobante.DetallesSalones.Any())
                {
                    foreach (var detalle in comprobante.DetallesSalones)
                    {
                        comprobanteDto.ComprobanteSalonDetalleDtos.Add(new ComprobanteSalonDetalleDto
                        {
                            Id = detalle.Id,
                            Descripcion = detalle.Descripcion,
                            Codigo = detalle.Codigo,
                            Cantidad = detalle.Cantidad,
                            SubTotal = detalle.SubTotal,
                            CodigoBarra = detalle.CodigoBarra,
                            ComprobanteSalonId = detalle.SalonId,
                            Precio = detalle.Precio,
                            ProductoId = detalle.ProductoId
                        });
                    }
                }

                return comprobanteDto;
            }
        }
        public IEnumerable<ComprobanteSalonDto> ObtenerComprobantesPorCliente(long? clienteId)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var comprobante = context.Comprobantes.OfType<Salon>()
                    .Include("DetallesSalones")
                    .Include("Mozo")
                    .Where(x => (x.ClienteId == clienteId
                                         && (x.TipoComprobante == TipoComprobante.Impaga)
                                         && (x.EstadoSalon == EstadoSalon.Pendiente)))
                                         .Select(x => new ComprobanteSalonDto
                                         {
                                             Id = x.Id,
                                             Total = x.Total,
                                             MesaId = x.MesaId,
                                             MozoId = x.MozoId,
                                             Mozo ="No Asignado",
                                             ClienteId = x.ClienteId

                                         }).ToList();
                
                if (comprobante == null)
                {
                    throw new ArgumentNullException("Error Grave");
                }
                return comprobante;
            }
        }
        public void EliminarItem(long comprobanteId, int cantidad, ProductoDto producto, long listaId)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var comprobante = context.Comprobantes.OfType<Salon>()
                    .Include(x => x.DetallesSalones)
                    .FirstOrDefault(x => x.Id == comprobanteId);

                if (comprobante == null) throw new Exception("Error");

                var item = comprobante.DetallesSalones
                    .FirstOrDefault(x => x.ProductoId == producto.Id
                    && x.Producto.ListasPreciosProductos.Any(l => l.ListaPrecioId == listaId));

                if (item != null)
                {
                    if (item.Cantidad !=0)
                    {
                        item.Cantidad -= cantidad;
                        item.SubTotal -= item.Precio;
                        producto.Stock += 1;
                    }
                    if (item.Cantidad == 0)
                    {
                        context.DetalleComprobantes.Remove(item);
                    }
                        
                }
                context.SaveChanges();
            }

        }
        public void DisminuirCantidadItem(long comprobanteId, ProductoDto producto, int cantidad)
        {

            using (var context = new ModeloGastronomiaContainer())
            {
                var comprobante = context.Comprobantes.OfType<Salon>()
                    .Include(x => x.DetallesSalones)
                    .FirstOrDefault(x => x.Id == comprobanteId);

                if (comprobante == null) throw new Exception("Error");

                var item = comprobante.DetallesSalones.FirstOrDefault(x =>
                x.ProductoId == producto.Id

                );

                if (item?.Cantidad > 0)
                {
                    item.Cantidad = item.Cantidad - cantidad;
                    item.SubTotal = item.Cantidad * item.Precio;
                }

                context.SaveChanges();
            }

        }
    }
}
