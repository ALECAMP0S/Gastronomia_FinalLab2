using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.Marca
{
    public class MarcaServicio : IMarcaServicio
    {
        public void Eliminar(MarcaDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var marca = context.Marcas.Find(dto.Id);
                context.Marcas.Remove(marca);
                context.SaveChanges();
            }
        }

        public void Insertar(MarcaDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {


                context.Marcas.Add(new DAL.Marca
                {
                    Codigo = dto.Codigo,
                    Descripcion = dto.Descripcion
                });

                context.SaveChanges();
            }
        }

        public void Modificar(MarcaDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {

                var marca = context.Marcas.Single(x => x.Id == dto.Id);

                marca.Codigo = dto.Codigo;
                marca.Descripcion = dto.Descripcion;

                context.SaveChanges();
            }
        }

        public IEnumerable<MarcaDto> ObtenerPorFiltro(string cadenaBuscar)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var codigo = -1;
                int.TryParse(cadenaBuscar, out codigo);

                var marcas = context.Marcas.AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar)
                                || x.Codigo == codigo)
                    .ToList();

                return marcas.Select(x => new MarcaDto()
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    Descripcion = x.Descripcion
                }).ToList();
            }
        }

        public MarcaDto ObtenerPorId(long id)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var marca = context.Marcas.Find(id);
                return new MarcaDto()
                {
                    Id = marca.Id,
                    Codigo = marca.Codigo,
                    Descripcion = marca.Descripcion
                };
            }
        }

        public int ObtenerSiguienteNumero()
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                return context.Marcas.Any() ? context.Marcas.Max(x => x.Codigo) + 1 : 1;
            }
        }

        public IEnumerable<MarcaDto> ObtenerTodo()
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var marcas = context.Marcas.AsNoTracking()
                    .ToList();

                return marcas.Select(x => new MarcaDto()
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    Descripcion = x.Descripcion
                }).ToList();
            }
        }

        public bool VerificarSiExiste(long? id, int numero)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                return context.Marcas.AsNoTracking()
                    .Any(x => x.Id != id && (x.Codigo == numero));
            }
        }

    }
}
