using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.Empleado
{
    public interface IEmpleadoServicio
    {
        IEnumerable<EmpleadoDto> ObtenerMozoPorId(string cadenaBuscar);

        IEnumerable<EmpleadoDto> ObtenerCadetePorId(string cadenaBuscar);

        EmpleadoDto ObtenerPorLegajo(string cadenaBuscar);

        void Insertar(EmpleadoDto dto);

        void Modificar(EmpleadoDto dto);

        void Eliminar(EmpleadoDto dto);

        EmpleadoDto ObtenerPorId(long id);
        IEnumerable<EmpleadoDto> ObtenerPorFiltro(string cadenaBuscar);

        bool VerificarSiExiste(long? empleadoId, int legajo);

        int ObtenerSiguienteLegajo();
    }
}
