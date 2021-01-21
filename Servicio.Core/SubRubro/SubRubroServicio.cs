using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Servicio.Core.SubRubro
{
    public class SubRubroServicio : ISubRubroServicio
    {
        public void Eliminar(SubRubroDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var Rubro = context.SubRubros.Find(dto.Id);
                context.SubRubros.Remove(Rubro);
                context.SaveChanges();
            }
        }

        public void Insertar(SubRubroDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {


                context.SubRubros.Add(new DAL.SubRubro
                {
                    Codigo = dto.Codigo,
                    Descripcion = dto.Descripcion,
                    RubroId = dto.RubroId
                });

                context.SaveChanges();
            }
        }

        public void Modificar(SubRubroDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {

                var subRubro = context.SubRubros.Single(x => x.Id == dto.Id);

                subRubro.Codigo = dto.Codigo;
                subRubro.Descripcion = dto.Descripcion;
                subRubro.RubroId = dto.RubroId;

                context.SaveChanges();
            }
        }

        public IEnumerable<SubRubroDto> ObtenerPorFiltro(string cadenaBuscar)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var codigo = -1;
                int.TryParse(cadenaBuscar, out codigo);

                var SubRubros = context.SubRubros.AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar)
                                || x.Codigo == codigo)
                    .ToList();

                return SubRubros.Select(x => new SubRubroDto()
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    Descripcion = x.Descripcion,
                    RubroId = x.RubroId
                }).ToList();
            }
        }

        public SubRubroDto ObtenerPorId(long id)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var Rubro = context.SubRubros.Find(id);
                return new SubRubroDto()
                {
                    Id = Rubro.Id,
                    Codigo = Rubro.Codigo,
                    Descripcion = Rubro.Descripcion,
                    RubroId = Rubro.RubroId
                };
            }
        }

        public int ObtenerSiguienteNumero()
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                return context.SubRubros.Any() ? context.SubRubros.Max(x => x.Codigo) + 1 : 1;
            }
        }

        public IEnumerable<SubRubroDto> ObtenerTodo()
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                return context.SubRubros.Select(x => new SubRubroDto()
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    Descripcion = x.Descripcion,
                    RubroId = x.RubroId

                }).ToList();
            }
        }

        public bool VerificarSiExiste(long? id, int numero)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                return context.SubRubros.AsNoTracking()
                    .Any(x => x.Id != id && (x.Codigo == numero));
            }
        }
    }
}
