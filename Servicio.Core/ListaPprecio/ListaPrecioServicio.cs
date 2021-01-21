using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using DAL;

namespace Servicio.Core.ListaPprecio
{
    public class ListaPrecioServicio : IListaPrecioServicio
    {
        public void Eliminar(ListaPrecioDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var listaEliminar = context.ListaPrecios
                    .Single(x => x.Id == dto.Id);

                context.ListaPrecios.Remove(listaEliminar);

                context.SaveChanges();
            }
        }

        public void Insertar(ListaPrecioDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                context.ListaPrecios.Add(new ListaPrecio
                {
                    Id = dto.Id,
                    Codigo = dto.Codigo,
                    Descripcion = dto.Descripcion
                });

                context.SaveChanges();
            }
        }

        public void Modificar(ListaPrecioDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var listaModificar = context.ListaPrecios
                    .Single(x => x.Id == dto.Id);

                listaModificar.Codigo = dto.Codigo;
                listaModificar.Descripcion = dto.Descripcion;

                context.SaveChanges();
            }
        }

        public IEnumerable<ListaPrecioDto> Obtener()
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                return context.ListaPrecios.
                    Select(x => new ListaPrecioDto
                    {
                        Codigo = x.Codigo,
                        Descripcion = x.Descripcion,
                        Id = x.Id
                    }).ToList();
            }
        }

        public IEnumerable<ListaPrecioDto> ObtenerPorFiltro(string cadenaBuscar)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var legajo = 1;
                int.TryParse(cadenaBuscar, out legajo);

                var empleados = context.ListaPrecios
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar)
                                || (x.Codigo == legajo))
                    .Select(x => new ListaPrecioDto
                    {
                        Id = x.Id,
                        Codigo = x.Codigo,
                        Descripcion = x.Descripcion

                    }).ToList();


                return empleados;
            }
        }

        public ListaPrecioDto ObtenerPorId(long id)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var empleado = context.ListaPrecios
                     .FirstOrDefault(x => x.Id == id);

                if (empleado == null) throw new ArgumentNullException("No existe el Empleado");

                return new ListaPrecioDto
                {
                    Id = empleado.Id,
                    Codigo = empleado.Codigo,
                    Descripcion = empleado.Descripcion
                };
            }
        }

        public ListaPrecioDto ObtenerPorLegajo(string cadenaBuscar)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var legajo = 1;
                int.TryParse(cadenaBuscar, out legajo);
                var empleado = context.ListaPrecios
                     .FirstOrDefault(x => x.Codigo == legajo);

                if (empleado == null) throw new ArgumentNullException("No existe el Empleado");

                return new ListaPrecioDto()
                {
                    Id = empleado.Id,
                    Codigo = empleado.Codigo,
                    Descripcion = empleado.Descripcion
                };
            }
        }
        public int ObtenerSiguienteLegajo()
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                return context.ListaPrecios
                    .Any()
                    ? context.ListaPrecios.Max(x => x.Codigo) + 1 : 1;
            }
        }

        public bool VerificarSiExiste(long? empleadoId, int legajo)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                return context.ListaPrecios
                    .Any(x => x.Id != empleadoId && x.Codigo == legajo);
            }
        }
    }
}
