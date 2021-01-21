using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.Rubro
{
    public class RubroServicio : IRubroServicio
    {
        public void Eliminar(RubroDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var Rubro = context.Rubros.Find(dto.Id);
                context.Rubros.Remove(Rubro);
                context.SaveChanges();
            }
        }

        public void Insertar(RubroDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {


                context.Rubros.Add(new DAL.Rubro
                {
                    Codigo = dto.Codigo,
                    Descripcion = dto.Descripcion
                });

                context.SaveChanges();
            }
        }

        public void Modificar(RubroDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {

                var Rubro = context.Rubros.Single(x => x.Id == dto.Id);

                Rubro.Codigo = dto.Codigo;
                Rubro.Descripcion = dto.Descripcion;

                context.SaveChanges();
            }
        }

        public IEnumerable<RubroDto> ObtenerPorFiltro(string cadenaBuscar)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var codigo = -1;
                int.TryParse(cadenaBuscar, out codigo);

                var Rubros = context.Rubros.AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar)
                                || x.Codigo == codigo)
                    .ToList();

                return Rubros.Select(x => new RubroDto()
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    Descripcion = x.Descripcion
                }).ToList();
            }
        }

        public RubroDto ObtenerPorId(long id)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var Rubro = context.Rubros.Find(id);
                return new RubroDto()
                {
                    Id = Rubro.Id,
                    Codigo = Rubro.Codigo,
                    Descripcion = Rubro.Descripcion
                };
            }
        }

        public int ObtenerSiguienteNumero()
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                return context.Rubros.Any() ? context.Rubros.Max(x => x.Codigo) + 1 : 1;
            }
        }

        public IEnumerable<RubroDto> ObtenerTodo()
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                return context.Rubros.Select(x => new RubroDto()
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
                return context.Rubros.AsNoTracking()
                    .Any(x => x.Id != id && (x.Codigo == numero));
            }
        }
    }
}
