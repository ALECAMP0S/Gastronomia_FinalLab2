using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.Proveedor
{
    public interface IProveedorServicio
    {
        void Insertar(ProveedorDto dto);

        void Modificar(ProveedorDto dto);

        void Eliminar(ProveedorDto dto);

        ProveedorDto ObtenerPorId(long id);
        IEnumerable<ProveedorDto> ObtenerPorFiltro(string cadenaBuscar);

        bool VerificarSiExiste(long empleadoId);
    }
}
