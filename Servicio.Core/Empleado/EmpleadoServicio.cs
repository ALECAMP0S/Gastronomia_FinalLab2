using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicio.Core.Producto;

namespace Servicio.Core.Empleado
{
    public class EmpleadoServicio : IEmpleadoServicio
    {
        public void Eliminar(EmpleadoDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var empleadoEliminar = context.Personas.OfType<DAL.Empleado>()
                    .Single(x => x.Id == dto.Id);

                empleadoEliminar.EstaEliminado = true;

                context.SaveChanges();
            }
        }

        public void Insertar(EmpleadoDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                context.Personas.Add(new DAL.Empleado
                {
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Teléfono = dto.Telefono,
                    Celular = dto.Celular,
                    Cuil = dto.Cuil,
                    TipoEmpleado = dto.TipoEmpleado,
                    EstaEliminado = false,
                    Direccion = dto.Direccion,
                    Legajo = dto.Legajo,
                    Dni = dto.Dni,
                    Usuario = new DAL.Usuario
                    {
                        EstaBloqueado = false,
                        Nombre = dto.Nombre,
                        Password = "1234"
                    }
                });


                context.SaveChanges();
            }
        }

        public void Modificar(EmpleadoDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var empleadoModificar = context.Personas.OfType<DAL.Empleado>()
                    .Single(x => x.Id == dto.Id);

                empleadoModificar.Legajo = dto.Legajo;
                empleadoModificar.Apellido = dto.Apellido;
                empleadoModificar.Direccion = dto.Direccion;
                empleadoModificar.Dni = dto.Dni;
                empleadoModificar.Nombre = dto.Nombre;
                empleadoModificar.Teléfono = dto.Telefono;
                empleadoModificar.Celular = dto.Celular;
                empleadoModificar.Cuil = dto.Cuil;
                empleadoModificar.TipoEmpleado = dto.TipoEmpleado;


                context.SaveChanges();
            }
        }

        public IEnumerable<EmpleadoDto> ObtenerPorFiltro(string cadenaBuscar)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var legajo = 1;
                int.TryParse(cadenaBuscar, out legajo);

                var empleados = context.Personas.OfType<DAL.Empleado>()
                    .AsNoTracking()
                    .Where(x => (x.Apellido.Contains(cadenaBuscar)
                                || x.Nombre.Contains(cadenaBuscar)
                                || x.Dni == cadenaBuscar
                                && (x.Legajo == legajo))
                                && (x.EstaEliminado == false))
                    .Select(x => new EmpleadoDto
                    {
                        Id = x.Id,
                        Legajo = x.Legajo,
                        Nombre = x.Nombre,
                        Apellido = x.Apellido,
                        Dni = x.Dni,
                        Telefono = x.Teléfono,
                        Celular = x.Celular,
                        Cuil = x.Cuil,
                        EstaEliminado = false,
                        TipoEmpleado = x.TipoEmpleado

                    }).ToList();


                return empleados;
            }
        }

        public EmpleadoDto ObtenerPorId(long id)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var empleado = context.Personas.OfType<DAL.Empleado>()
                     .FirstOrDefault(x => x.Id == id);

                if (empleado == null) throw new ArgumentNullException("No existe el Empleado");

                return new EmpleadoDto
                {
                    Id = empleado.Id,
                    Apellido = empleado.Apellido,
                    Dni = empleado.Dni,
                    Nombre = empleado.Nombre,
                    Legajo = empleado.Legajo,
                    Telefono = empleado.Teléfono,
                    Direccion = empleado.Direccion,
                    Cuil = empleado.Cuil,
                    Celular = empleado.Celular,
                    EstaEliminado = empleado.EstaEliminado

                };
            }
        }

        public int ObtenerSiguienteLegajo()
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                return context.Personas.OfType<DAL.Empleado>()
                    .Any()
                    ? context.Personas.OfType<DAL.Empleado>().Max(x => x.Legajo) + 1 : 1;
            }
        }

        public bool VerificarSiExiste(long? empleadoId, int legajo)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                return context.Personas.OfType<DAL.Empleado>()
                    .Any(x => x.Id != empleadoId && x.Legajo == legajo);
            }
        }
        public IEnumerable<EmpleadoDto> ObtenerMozoPorId( string cadenaBuscar)
        {
            var context = new ModeloGastronomiaContainer();

            var legajo = 1;
            int.TryParse(cadenaBuscar, out legajo);

            return context.Personas.OfType<DAL.Empleado>()
                .AsNoTracking()
                .Where(x => (x.Apellido.Contains(cadenaBuscar)
                             || x.Nombre == cadenaBuscar
                             && (x.Legajo == legajo)
                             && (x.EstaEliminado == false))
                            && (x.TipoEmpleado == TipoEmpleado.Mozo))
                            .Select(x => new EmpleadoDto()
                            {
                                Id = x.Id,
                                Apellido = x.Apellido,
                                Nombre = x.Nombre,
                                Telefono = x.Teléfono,
                                Dni = x.Dni,
                                Cuil = x.Cuil,
                                Celular = x.Celular,
                                Direccion = x.Direccion,
                                Legajo = x.Legajo,
                                TipoEmpleado = x.TipoEmpleado

                            });
        }

        public IEnumerable<EmpleadoDto> ObtenerCadetePorId(string cadenaBuscar)
        {
            var context = new ModeloGastronomiaContainer();

            var legajo = 1;
            int.TryParse(cadenaBuscar, out legajo);

            return context.Personas.OfType<DAL.Empleado>()
                .AsNoTracking()
                .Where(x => (x.Apellido.Contains(cadenaBuscar)
                             || x.Nombre == cadenaBuscar
                             && (x.Legajo == legajo)
                             && (x.EstaEliminado == false))
                            && (x.TipoEmpleado == TipoEmpleado.Cadete))
                            .Select(x => new EmpleadoDto()
                            {
                                Id = x.Id,
                                Apellido = x.Apellido,
                                Nombre = x.Nombre,
                                Telefono = x.Teléfono,
                                Dni = x.Dni,
                                Cuil = x.Cuil,
                                Celular = x.Celular,
                                Direccion = x.Direccion,
                                Legajo = x.Legajo,
                                TipoEmpleado = x.TipoEmpleado

                            });
        }
        public EmpleadoDto ObtenerPorLegajo(string cadenaBuscar)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var legajo = 1;
                int.TryParse(cadenaBuscar, out legajo);
                var empleado = context.Personas.OfType<DAL.Empleado>()
                     .FirstOrDefault(x => x.Legajo == legajo);

                if (empleado == null) throw new ArgumentNullException("No existe el Empleado");

                return new EmpleadoDto
                {
                    Id = empleado.Id,
                    Apellido = empleado.Apellido,
                    Dni = empleado.Dni,
                    Nombre = empleado.Nombre,
                    Legajo = empleado.Legajo,
                    Telefono = empleado.Teléfono,
                    Direccion = empleado.Direccion,
                    Cuil = empleado.Cuil,
                    Celular = empleado.Celular,
                    EstaEliminado = empleado.EstaEliminado

                };
            }
        }

       
    }
}
