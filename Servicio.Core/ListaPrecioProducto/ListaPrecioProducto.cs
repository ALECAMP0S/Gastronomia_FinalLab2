using DAL;
using Servicio.Core.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.ListaPrecioProducto
{
    public class ListaPrecioProductos : IListaPrecioProducto
    {
        public IEnumerable<ProductoDto> ObtenerLista(string cadenabuscar, long listaid)
        {

            var codigo = 0;
            int.TryParse(cadenabuscar, out codigo);

            var context = new ModeloGastronomiaContainer();


            return context.Productos.Include("ListaPrecioProducto")
                .Where(x => (x.Descripcion.Contains(cadenabuscar)
                             || x.Codigo == codigo
                             || x.CodigoBarra == cadenabuscar) &&
                            x.ListasPreciosProductos.Any(l => l.ListaPrecioId == listaid))
                .Select(x => new ProductoDto()
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    CodigoBarra = x.CodigoBarra,
                    Descripcion = x.Descripcion,

                    FechaActualizacion = x.ListasPreciosProductos.FirstOrDefault(h => h.ListaPrecioId == listaid
                   && h.FechaActualizacion == context.ListaPrecioProductos.Where(p => p.ListaPrecioId == listaid
                   && p.ProductoId == x.Id).Max(f => f.FechaActualizacion)).FechaActualizacion,

                    Stock = x.Stock,

                    PrecioPublico = x.ListasPreciosProductos.FirstOrDefault(h => h.ListaPrecioId == listaid
                    && h.FechaActualizacion == context.ListaPrecioProductos.Where(p => p.ListaPrecioId == listaid
                    && p.ProductoId == x.Id).Max(f => f.FechaActualizacion)).PrecioPublico

                    });
        }

        public ProductoDto ObtnerProducto(string cadenabuscar, long listaid)
        {
            var codigo = 0;
            int.TryParse(cadenabuscar, out codigo);

            var context = new ModeloGastronomiaContainer();


            if (context.ListaPrecioProductos.Any(x => x.ListaPrecioId == listaid && (x.Producto.CodigoBarra == cadenabuscar || x.Producto.Codigo == codigo)))
            {

                var fecha =
                    context.ListaPrecioProductos.Where(x => x.ListaPrecioId == listaid && (x.Producto.CodigoBarra == cadenabuscar || x.Producto.Codigo == codigo))
                        .Max(a => a.FechaActualizacion);

                var producto =
                    context.ListaPrecioProductos.FirstOrDefault(
                        x => x.ListaPrecioId == listaid && (x.Producto.CodigoBarra == cadenabuscar || x.Producto.Codigo == codigo) && x.FechaActualizacion == fecha)
                        .Producto;

                var productoDto = new ProductoDto()
                {
                    Id = producto.Id,
                    Codigo = producto.Codigo,
                    CodigoBarra = producto.CodigoBarra,
                    Descripcion = producto.Descripcion,

                    FechaActualizacion = producto.ListasPreciosProductos.FirstOrDefault(h => h.ListaPrecioId == listaid
                                                                                             &&
                                                                                             h.FechaActualizacion ==
                                                                                             fecha).FechaActualizacion,

                    Stock = producto.Stock,
                    PrecioPublico = producto.ListasPreciosProductos.FirstOrDefault(h => h.ListaPrecioId == listaid
                                                                                        && h.FechaActualizacion == fecha)
                        .PrecioPublico
                };
                return productoDto;
            }
            return null;
        }

        public IEnumerable<ListaPrecioProductoDto> ObtenerTodo()
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var listas = context.ListaPrecioProductos.Where(x => x.EstaEliminada == false).Select(x => new ListaPrecioProductoDto()
                {
                    Alicuota = x.Alicuota,
                    Fecha = x.FechaActualizacion,
                    ListaPrecioId = x.ListaPrecioId,
                    ListaPrecioStr = x.ListaPrecio.Descripcion,
                    ProductoId = x.ProductoId,
                    PrecioPublico = x.PrecioPublico,
                    PrecioCosto = x.PrecioCosto,
                    ProductoStr = x.Producto.Descripcion,
                    Id = x.Id
                }).ToList();

                return listas;



            }
        }

        public void CrearListaPrecioProducto(ListaPrecioProductoDto lista)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var listaAgregar = new DAL.ListaPrecioProducto()
                {
                    Alicuota = 21,
                    FechaActualizacion = lista.Fecha,
                    ListaPrecioId = Convert.ToInt64(lista.ListaPrecioId),
                    ProductoId = Convert.ToInt32(lista.ProductoId),
                    PrecioCosto = lista.PrecioCosto,
                    PrecioPublico = lista.PrecioPublico

                };
                context.ListaPrecioProductos.Add(listaAgregar);
                context.SaveChanges();

            }
        }

        public void Eliminar(ListaPrecioProductoDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var empleado = context.ListaPrecioProductos.OfType<DAL.ListaPrecioProducto>().
                    FirstOrDefault(x => x.Id == dto.Id);

                if (empleado != null) empleado.EstaEliminada = true;

                context.SaveChanges();
            }

        }


        public void Modificar(ListaPrecioProductoDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var listaPrecio = context.ListaPrecioProductos.FirstOrDefault(x => x.Id == dto.Id);

                if (listaPrecio != null)
                {
                    listaPrecio.ListaPrecioId = dto.ListaPrecioId;
                    listaPrecio.ProductoId = Convert.ToInt32(dto.ProductoId);
                    listaPrecio.PrecioCosto = dto.PrecioCosto;
                    listaPrecio.PrecioPublico = dto.PrecioPublico;
                    listaPrecio.Alicuota = 21;
                    listaPrecio.FechaActualizacion = dto.Fecha;
                }
                context.SaveChanges();
            }

        }


        public ListaPrecioProductoDto ObtenerPorId(long Id)
        {

            using (var context = new ModeloGastronomiaContainer())
            {
                var ListaPrecio = context.ListaPrecioProductos.FirstOrDefault(x => x.Id == Id);

                if (ListaPrecio == null) throw new ArgumentNullException(@"No existe la Lista");

                return new ListaPrecioProductoDto
                {
                    Id = ListaPrecio.Id,
                    Alicuota = ListaPrecio.Alicuota,
                    Fecha = ListaPrecio.FechaActualizacion,
                    ListaPrecioId = ListaPrecio.ListaPrecioId,
                    ProductoId = ListaPrecio.ProductoId,
                    PrecioCosto = ListaPrecio.PrecioCosto,
                    PrecioPublico = ListaPrecio.PrecioPublico

                };

            }
        }

        public ListaPrecioProductoDto ObtenerListaPorProductoId(long Id)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var lista = context.ListaPrecioProductos.FirstOrDefault(x => x.ProductoId == Id);
                return new ListaPrecioProductoDto()
                {
                    Id = lista.Id,
                    ProductoId = lista.ProductoId,
                    Alicuota = lista.Alicuota,
                    Fecha = lista.FechaActualizacion,
                    PrecioPublico = lista.PrecioPublico,
                    ListaPrecioId = lista.ListaPrecioId,
                    PrecioCosto = lista.PrecioCosto,


                };
            }
        }

    }
}
