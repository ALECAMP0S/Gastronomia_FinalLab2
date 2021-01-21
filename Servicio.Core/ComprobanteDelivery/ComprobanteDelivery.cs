using DAL;
using Servicio.Core.Producto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.ComprobanteDelivery
{
    public class ComprobanteDelivery : IComprobanteDelivery
    {
        public void AgregarItem(long comprobanteId, int cantidad, ProductoDto producto, long listaId)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var comprobante = context.Comprobantes.OfType<Delivery>()
                    .Include(x => x.DetallesDeliveries)
                    .FirstOrDefault(x => x.Id == comprobanteId);

                if (comprobante == null) throw new Exception("Error");
                if (producto != null)
                {
                    var item = comprobante.DetallesDeliveries
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
                            item.SubTotal = item.Cantidad * producto.PrecioPublico;
                            producto.Stock -= 1;
                            comprobante.Total = item.SubTotal;
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

        private static void CargarNuevoItem(int cantidad, ProductoDto producto, Delivery comprobante)
        {
            // En caso de que no exista el producto en el Detalle
            comprobante.DetallesDeliveries.Add(new DetalleDelivery
            {
                Cantidad = cantidad,
                Codigo = producto.Codigo.ToString(),
                CodigoBarra = producto.CodigoBarra,
                Descripcion = producto.Descripcion,
                Precio = producto.PrecioPublico,
                ProductoId = producto.Id,
                SubTotal = producto.PrecioPublico * cantidad
                
                
            });
            comprobante.Total = producto.PrecioPublico * cantidad;
                
        }

        public void Crear(long clienteId, ComprobanteDeliveryDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var nuevoComprobane = new Delivery
                {
                    Fecha = DateTime.Now,
                    EstadoDelivery = EstadoDelivery.EnProceso,
                    TipoComprobante = TipoComprobante.Impaga,
                    ClienteId = clienteId,
                    Recargo = 0m,
                    DireccionEnvio = dto.Direccion,
                    Total = dto.Total,
                    Observacion = " ",
                    EmpleadoId = dto.CadeteId
                };

                context.Comprobantes.Add(nuevoComprobane);
               context.SaveChanges();
            }
        }

        public void QuitarComprobante(long clienteId)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var quitarComprobante = context.Comprobantes.OfType<Delivery>()
                    .Include("DetallesDeliveries")
                    .Include("Cliente")
                    .FirstOrDefault(x => x.ClienteId == clienteId
                    && x.EstadoDelivery == EstadoDelivery.Enviado);

                quitarComprobante.EstadoDelivery = EstadoDelivery.Cobrado;
                quitarComprobante.TipoComprobante = TipoComprobante.Pagada;

                context.SaveChanges();

            }
        }
        public void ComprobanteCtaCte(long clienteId)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var quitarComprobante = context.Comprobantes.OfType<Delivery>()
                    .Include("DetallesDeliveries")
                    .Include("Cliente")
                    .FirstOrDefault(x => x.ClienteId == clienteId
                    && x.EstadoDelivery == EstadoDelivery.EnProceso);

                quitarComprobante.EstadoDelivery = EstadoDelivery.Enviado;
                quitarComprobante.TipoComprobante = TipoComprobante.Impaga;
                context.SaveChanges();

            }
        }
        public ComprobanteDeliveryDto ObtenerComprobantePorId(long comprobanteId)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var comprobante = context.Comprobantes.OfType<Delivery>()
                    .Include("DetallesDeliveries")
                    .Include("Empleado")
                    .FirstOrDefault(x => x.Id == comprobanteId
                                         && x.EstadoDelivery == EstadoDelivery.Cobrado
                                         && x.EstadoDelivery != EstadoDelivery.EnProceso
                                         && x.TipoComprobante == TipoComprobante.Impaga);


                var comprobanteDto = new ComprobanteDeliveryDto
                {
                    Id = comprobante.Id,
                    Total = comprobante.Total,
                    CadeteId = comprobante.EmpleadoId,
                    Cadete =  "No Asignado",
                    ClienteId = comprobante.ClienteId,
                    Direccion = comprobante.DireccionEnvio
                };

                if (comprobante.DetallesDeliveries != null
                    && comprobante.DetallesDeliveries.Any())
                {
                    foreach (var detalle in comprobante.DetallesDeliveries)
                    {
                        comprobanteDto.ComprobanteDeliveryDetalleDtos.Add(new ComprobanteDeliveryDetalleDto
                        {
                            Id = detalle.Id,
                            Descripcion = detalle.Descripcion,
                            Codigo = detalle.Codigo,
                            Cantidad = detalle.Cantidad,
                            SubTotal = detalle.SubTotal,
                            CodigoBarra = detalle.CodigoBarra,
                            Precio = detalle.Precio,
                            ProductoId = detalle.ProductoId,
                            ComprobanteDeliveryId = detalle.DeliveryId
                        });
                    }
                }

                return comprobanteDto;
            }
        }
        public ComprobanteDeliveryDto ObtenerComprobantePorCliente(long clienteId)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var comprobante = context.Comprobantes.OfType<Delivery>()
                    .Include("DetallesDeliveries")
                    .Include("Cliente")
                    .FirstOrDefault(x => x.ClienteId == clienteId
                                         && x.EstadoDelivery == EstadoDelivery.EnProceso
                                         && x.EstadoDelivery != EstadoDelivery.Cobrado);

                if (comprobante == null) throw new ArgumentNullException("Error Grave");

                var comprobanteDto = new ComprobanteDeliveryDto
                {
                    Id = comprobante.Id,
                    Total = comprobante.Total,
                    ClienteId = comprobante.ClienteId,
                    CadeteId = comprobante.EmpleadoId,
                    Cadete = comprobante.EmpleadoId != null ? $"{comprobante.Empleado.Apellido} {comprobante.Empleado.Nombre}" : "No Asignado"
                };

                if (comprobante.DetallesDeliveries != null
                    && comprobante.DetallesDeliveries.Any())
                {
                    foreach (var detalle in comprobante.DetallesDeliveries)
                    {
                        comprobanteDto.ComprobanteDeliveryDetalleDtos.Add(new ComprobanteDeliveryDetalleDto
                        {
                            Id = detalle.Id,
                            Descripcion = detalle.Descripcion,
                            Codigo = detalle.Codigo,
                            Cantidad = detalle.Cantidad,
                            SubTotal = detalle.SubTotal,
                            CodigoBarra = detalle.CodigoBarra,
                            ComprobanteDeliveryId = detalle.DeliveryId,
                            Precio = detalle.Precio,
                            ProductoId = detalle.ProductoId
                        });
                    }
                }

                return comprobanteDto;
            }
        }
        public IEnumerable<ComprobanteDeliveryDto> ObtenerComprobantesPorCliente(long? clienteId)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var comprobante = context.Comprobantes.OfType<Delivery>()
                    .Include("DetallesDeliveries")
                    .Include("Empleado")
                    .Where(x => (x.ClienteId == clienteId
                                         && (x.TipoComprobante == TipoComprobante.Impaga)
                                         && (x.EstadoDelivery == EstadoDelivery.Enviado)))
                                         .Select(x => new ComprobanteDeliveryDto
                                         {
                                             Id = x.Id,
                                             Total = x.Total,
                                             ClienteId = x.ClienteId,
                                             CadeteId = x.EmpleadoId,
                                             Cadete = "No Asignado"
                                             

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
                var comprobante = context.Comprobantes.OfType<Delivery>()
                    .Include(x => x.DetallesDeliveries)
                    .FirstOrDefault(x => x.Id == comprobanteId);

                if (comprobante == null) throw new Exception("Error");

                var item = comprobante.DetallesDeliveries
                    .FirstOrDefault(x => x.ProductoId == producto.Id
                    && x.Producto.ListasPreciosProductos.Any(l => l.ListaPrecioId == listaId));

                if (item != null)
                {
                    if (item.Cantidad != 0)
                    {
                        item.Cantidad -= cantidad;
                        item.SubTotal -= item.Precio;
                        producto.Stock += 1;
                        comprobante.Total = item.SubTotal;
                    }
                    if (item.Cantidad == 0)
                    {
                        context.DetalleComprobantes.Remove(item);
                    }

                }
                context.SaveChanges();
            }
        }
    }
}
