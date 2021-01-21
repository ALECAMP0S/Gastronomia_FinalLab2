using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.SubRubro
{
    public interface ISubRubroServicio
    {
        void Insertar(SubRubroDto dto);

        void Modificar(SubRubroDto dto);

        void Eliminar(SubRubroDto dto);

        SubRubroDto ObtenerPorId(long id);
        IEnumerable<SubRubroDto> ObtenerPorFiltro(string cadenaBuscar);
        IEnumerable<SubRubroDto> ObtenerTodo();

        bool VerificarSiExiste(long? id, int numero);

        int ObtenerSiguienteNumero();
    }
}
