using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Entity;
using Presentacion.Base.Varios;

namespace Servicio.Core.Producto
{
    public class ProductoServicio : IProductoServicio
    {
        public IEnumerable<ProductoDto> ObtenerPorListaPrecio(long listaPrecioId, string cadenaBuscar)
        {
            var context = new ModeloGastronomiaContainer();

            var codigo = 1;
            int.TryParse(cadenaBuscar, out codigo);
            return context.Productos
                .Include("ListasPreciosProductos")
                .Where(x => (x.Descripcion.Contains(cadenaBuscar)
                             || x.Codigo == codigo
                             || x.CodigoBarra == cadenaBuscar)
                            && x.ListasPreciosProductos.Any(l => l.ListaPrecioId == listaPrecioId))
                .Select(x => new ProductoDto
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    CodigoBarra = x.CodigoBarra,
                    Descripcion = x.Descripcion,
                    Stock = x.Stock,
                    PrecioPublico = x.ListasPreciosProductos
                        .FirstOrDefault(l => l.ListaPrecioId == listaPrecioId
                                             &&
                                             l.FechaActualizacion ==
                                             context.ListaPrecioProductos.Where(p => p.ListaPrecioId == listaPrecioId
                                                                                     && p.ProductoId == x.Id)
                                                 .Max(f => f.FechaActualizacion)).PrecioPublico

                });
        }
        public IEnumerable<ProductoDto> ObtenerTodo()
        {
            using (var context = new ModeloGastronomiaContainer())
            {


                var subrubros = context.Productos.AsNoTracking()
                    .ToList();

                return subrubros.Select(x => new ProductoDto()
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    Descripcion = x.Descripcion,
                    MarcaId = x.MarcaId,
                    SubRubroId = x.SubRubroId,
                    Stock = x.Stock,

                }).ToList();
            }
        }
        public ProductoDto ObtenerPorDescripcion(string cadenaBuscar, long listaPrecioId)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var codigo = 1;
                int.TryParse(cadenaBuscar, out codigo);
                var producto = context.Productos
                    .Include("ListasPreciosProductos")
                    .FirstOrDefault(x => x.CodigoBarra == cadenaBuscar
                    || x.Codigo == codigo
                    && x.ListasPreciosProductos.Any(l => l.ListaPrecioId == listaPrecioId));

                if (producto == null)
                {
                    Mensaje.Mostrar("No existe el producto", Mensaje.Tipo.Informacion);
                }
                else
                {


                    return new ProductoDto()
                    {
                        Id = producto.Id,
                        Descripcion = producto.Descripcion,
                        CodigoBarra = producto.CodigoBarra,
                        Codigo = producto.Codigo,
                        Stock = producto.Stock,
                        PrecioPublico = producto.ListasPreciosProductos.FirstOrDefault(l => l.ListaPrecioId == listaPrecioId)
                                .PrecioPublico
                    };
                }
                return null;
            }


        }
        public ProductoDto ObtenerPorId(long id)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var producto = context.Productos.OfType<DAL.Producto>()
                    .FirstOrDefault(x => x.Id == id);

                if (producto == null) throw new ArgumentNullException("No existe el Producto");

                return new ProductoDto()
                {
                    Id = producto.Id,
                    Descripcion = producto.Descripcion,
                    CodigoBarra = producto.CodigoBarra,
                    Codigo = producto.Codigo,
                    Stock = producto.Stock,
                    SubRubroId = producto.SubRubroId,
                    MarcaId = producto.MarcaId
                };
            }
        }

        public void Eliminar(ProductoDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var productoEliminar = context.Productos.OfType<DAL.Producto>()
                    .Single(x => x.Id == dto.Id);

                context.Productos.Remove(productoEliminar);

                context.SaveChanges();
            }
        }

        public void Insertar(ProductoDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                context.Productos.Add(new DAL.Producto
                {
                    Codigo = dto.Codigo,
                    CodigoBarra = dto.CodigoBarra,
                    Descripcion = dto.Descripcion,
                    Stock = dto.Stock,
                    MarcaId = dto.MarcaId,
                    SubRubroId = dto.SubRubroId

                });


                context.SaveChanges();
            }
        }

        public void Modificar(ProductoDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var productoModificar = context.Productos.OfType<DAL.Producto>()
                    .Single(x => x.Id == dto.Id);

                productoModificar.Codigo = dto.Codigo;
                productoModificar.CodigoBarra = dto.CodigoBarra;
                productoModificar.Descripcion = dto.Descripcion;
                productoModificar.Stock = dto.Stock;
                productoModificar.MarcaId = dto.MarcaId;
                productoModificar.SubRubroId = dto.SubRubroId;


                context.SaveChanges();
            }
        }

        public IEnumerable<ProductoDto> ObtenerPorFiltro(string cadenaBuscar)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var codigo = 1;
                int.TryParse(cadenaBuscar, out codigo);

                var productos = context.Productos.OfType<DAL.Producto>()
                    .Where(x => (x.Descripcion.Contains(cadenaBuscar)
                                || x.CodigoBarra.Contains(cadenaBuscar)
                                && x.Codigo == codigo))
                .Select(x => new ProductoDto
                {
                    Codigo = x.Codigo,
                    CodigoBarra = x.CodigoBarra,
                    Descripcion = x.Descripcion,
                    MarcaId = x.MarcaId,
                    SubRubroId = x.SubRubroId,
                    Stock = x.Stock

                }).ToList();


                return productos;
            }
        }

        public int ObtenerSiguienteLegajo()
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                return context.Productos
                    .Any()
                    ? context.Productos.Max(x => x.Codigo) + 1 : 1;

            }
        }

        public bool VerificarSiExiste(long? empleadoId, int legajo)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                return context.Productos.OfType<DAL.Producto>()
                    .Any(x => x.Id != empleadoId && x.Codigo == legajo);
            }
        }

    }

}
