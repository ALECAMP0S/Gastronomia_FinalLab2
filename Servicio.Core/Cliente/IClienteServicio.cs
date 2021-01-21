using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.Cliente
{
    public interface IClienteServicio
    {
        void Insertar(ClienteDto dto);

        void Modificar(ClienteDto dto);

        void Eliminar(ClienteDto dto);

        ClienteDto ObtenerPorId(long id);

        IEnumerable<ClienteDto> ObtenerPorFiltro(string cadenaBuscar);

        IEnumerable<ClienteDto> ObtenerClientesCtaCte(string cadenaBuscar);

        bool VerificarSiExiste(long? empleadoId, int codigo);

        int ObtenerSiguienteCodigo();
    }
}
