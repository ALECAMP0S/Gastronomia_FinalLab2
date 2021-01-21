using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.Cliente
{
    public class ClienteServicio : IClienteServicio
    {
        public void Eliminar(ClienteDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var clienteEliminar = context.Personas.OfType<DAL.Cliente>()
                    .Single(x => x.Id == dto.Id);

                clienteEliminar.EstaEliminado = true;

                context.SaveChanges();
            }
        }

        public void Insertar(ClienteDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                context.Personas.Add(new DAL.Cliente
                {
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Teléfono = dto.Telefono,
                    Celular = dto.Celular,
                    Cuil = dto.Cuil,
                    EstaEliminado = false,
                    Direccion = dto.Direccion,
                    Codigo = dto.Codigo,
                    Dni = dto.Dni,
                    TieneCtaCte = dto.TieneCtaCte,
                    MontoMaximoCtaCte = dto.MontoMaximoCtaCte,
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

        public void Modificar(ClienteDto dto)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var clienteModificar = context.Personas.OfType<DAL.Cliente>()
                    .Single(x => x.Id == dto.Id);

                clienteModificar.Codigo = dto.Codigo;
                clienteModificar.Apellido = dto.Apellido;
                clienteModificar.Direccion = dto.Direccion;
                clienteModificar.Dni = dto.Dni;
                clienteModificar.Nombre = dto.Nombre;
                clienteModificar.Teléfono = dto.Telefono;
                clienteModificar.Celular = dto.Celular;
                clienteModificar.Cuil = dto.Cuil;
                clienteModificar.TieneCtaCte = dto.TieneCtaCte;
                clienteModificar.MontoMaximoCtaCte = dto.MontoMaximoCtaCte;

                context.SaveChanges();
            }
        }

        public IEnumerable<ClienteDto> ObtenerPorFiltro(string cadenaBuscar)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var codigo = 1;
                int.TryParse(cadenaBuscar, out codigo);

                var clientes = context.Personas.OfType<DAL.Cliente>()
                    .AsNoTracking()
                    .Where(x => (x.Apellido.Contains(cadenaBuscar)
                                || x.Nombre.Contains(cadenaBuscar)
                                || x.Dni == cadenaBuscar
                                && (x.Codigo == codigo))
                                && (x.EstaEliminado == false))
                    .Select(x => new ClienteDto
                    {
                        Id = x.Id,
                        Codigo = x.Codigo,
                        Nombre = x.Nombre,
                        Apellido = x.Apellido,
                        Dni = x.Dni,
                        Telefono = x.Teléfono,
                        Celular = x.Celular,
                        Cuil = x.Cuil,
                        Direccion = x.Direccion,
                        TieneCtaCte = x.TieneCtaCte,
                        MontoMaximoCtaCte = x.MontoMaximoCtaCte

                    }).ToList();


                return clientes;
            }
        }
        public IEnumerable<ClienteDto> ObtenerClientesCtaCte(string cadenaBuscar)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var codigo = 1;
                int.TryParse(cadenaBuscar, out codigo);

                var clientes = context.Personas.OfType<DAL.Cliente>()
                    .AsNoTracking()
                    .Where(x => (x.Apellido.Contains(cadenaBuscar)
                                || x.Nombre.Contains(cadenaBuscar)
                                || x.Dni == cadenaBuscar
                                && (x.Codigo == codigo))
                                && (x.EstaEliminado == false)
                                && (x.TieneCtaCte == true ))
                    .Select(x => new ClienteDto
                    {
                        Id = x.Id,
                        Codigo = x.Codigo,
                        Nombre = x.Nombre,
                        Apellido = x.Apellido,
                        Dni = x.Dni,
                        Telefono = x.Teléfono,
                        Celular = x.Celular,
                        Cuil = x.Cuil,
                        Direccion = x.Direccion,
                        TieneCtaCte = x.TieneCtaCte,
                        MontoMaximoCtaCte = x.MontoMaximoCtaCte

                    }).ToList();


                return clientes;
            }
        }
        public ClienteDto ObtenerPorId(long id)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                var cliente = context.Personas.OfType<DAL.Cliente>()
                     .FirstOrDefault(x => x.Id == id);

                if (cliente == null) throw new ArgumentNullException("No existe el cliente");

                return new ClienteDto
                {
                    Id = cliente.Id,
                    Apellido = cliente.Apellido,
                    Dni = cliente.Dni,
                    Nombre = cliente.Nombre,
                    Codigo = cliente.Codigo,
                    Telefono = cliente.Teléfono,
                    Direccion = cliente.Direccion,
                    Cuil = cliente.Cuil,
                    Celular = cliente.Celular,
                    TieneCtaCte = cliente.TieneCtaCte,
                    MontoMaximoCtaCte = cliente.MontoMaximoCtaCte
                };
            }
        }

        public int ObtenerSiguienteCodigo()
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                return context.Personas.OfType<DAL.Cliente>()
                    .Any()
                    ? context.Personas.OfType<DAL.Cliente>().Max(x => x.Codigo) + 1 : 1;
            }
        }

        public bool VerificarSiExiste(long? clienteId, int codigo)
        {
            using (var context = new ModeloGastronomiaContainer())
            {
                return context.Personas.OfType<DAL.Cliente>()
                    .Any(x => x.Id != clienteId && x.Codigo == codigo);
            }
        }


    }
}
