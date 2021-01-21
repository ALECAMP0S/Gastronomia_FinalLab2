using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.Proveedor
{
    public class ProveedorServicio : IProveedorServicio
    {
        public void Eliminar(ProveedorDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var empleadoEliminar = context.Personas.OfType<DAL.Proveedor>()
                    .Single(x => x.Id == dto.Id);

                empleadoEliminar.EstaEliminado = true;

                context.SaveChanges();
            }
        }

        public void Insertar(ProveedorDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                context.Personas.Add(new DAL.Proveedor
                {
                    NombreFantacia = dto.NombreFantacia,
                    CondicionIvaId = dto.CondicionIva,
                    EstaEliminado = false,
                    Direccion = dto.Direccion,
                    Cuit = dto.Cuil,
                    IngresosBrutos = dto.IngresosBrutos,
                    FechaInicioActividad = DateTime.Now,
                    Teléfono = dto.Telefono,
                    RazonSocial = dto.RazonSocial,
                    ApyNomContacto = dto.ApyNomContacto,
                    Usuario = new DAL.Usuario
                    {
                        EstaBloqueado = false,
                        Nombre = dto.NombreFantacia,
                        Password = "1234"
                    }
                });


                context.SaveChanges();
            }
        }

        public void Modificar(ProveedorDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var proveedorModificar = context.Personas.OfType<DAL.Proveedor>()
                    .Single(x => x.Id == dto.Id);

                proveedorModificar.NombreFantacia = dto.NombreFantacia;
                proveedorModificar.CondicionIvaId = dto.CondicionIva;
                proveedorModificar.Direccion = dto.Direccion;
                proveedorModificar.FechaInicioActividad = dto.FechaIncioActividad;
                proveedorModificar.ApyNomContacto = dto.ApyNomContacto;
                proveedorModificar.Teléfono = dto.Telefono;
                proveedorModificar.IngresosBrutos = dto.IngresosBrutos;
                proveedorModificar.Cuit = dto.Cuil;
                proveedorModificar.RazonSocial = dto.RazonSocial;

                context.SaveChanges();
            }
        }

        public IEnumerable<ProveedorDto> ObtenerPorFiltro(string cadenaBuscar)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var codigo = 1;
                int.TryParse(cadenaBuscar, out codigo);

                var proveedors = context.Personas.OfType<DAL.Proveedor>()
                    .AsNoTracking()
                    .Where(x => (x.NombreFantacia.Contains(cadenaBuscar)
                                || x.Teléfono == cadenaBuscar
                                && (x.ApyNomContacto.Contains(cadenaBuscar))
                                && (x.Id == codigo))
                                && (x.EstaEliminado == false))
                    .Select(x => new ProveedorDto
                    {
                        Id = x.Id,
                        CondicionIva = x.CondicionIvaId,
                        Telefono = x.Teléfono,
                        Cuil = x.Cuit,
                        Direccion = x.Direccion,
                        IngresosBrutos = x.IngresosBrutos,
                        NombreFantacia = x.NombreFantacia,
                        FechaIncioActividad = x.FechaInicioActividad,
                        RazonSocial = x.RazonSocial

                    }).ToList();


                return proveedors;
            }
        }

        public ProveedorDto ObtenerPorId(long id)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var proveedor = context.Personas.OfType<DAL.Proveedor>()
                     .FirstOrDefault(x => x.Id == id);

                if (proveedor == null) throw new ArgumentNullException("No existe el proveedor");

                return new ProveedorDto
                {
                    Id = proveedor.Id,
                    Telefono = proveedor.Teléfono,
                    Direccion = proveedor.Direccion,
                    Cuil = proveedor.Cuit,
                    NombreFantacia = proveedor.NombreFantacia,
                    RazonSocial = proveedor.RazonSocial,
                    CondicionIva = proveedor.CondicionIvaId,
                    FechaIncioActividad = proveedor.FechaInicioActividad,
                    IngresosBrutos = proveedor.IngresosBrutos

                };
            }
        }


        public bool VerificarSiExiste(long proveedorId)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                return context.Personas.OfType<DAL.Proveedor>()
                    .Any(x => x.Id != proveedorId);
            }
        }
    }
}
