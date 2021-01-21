using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.Rubro
{
    public interface IRubroServicio
    {
        void Insertar(RubroDto dto);

        void Modificar(RubroDto dto);

        void Eliminar(RubroDto dto);

        RubroDto ObtenerPorId(long id);
        IEnumerable<RubroDto> ObtenerPorFiltro(string cadenaBuscar);
        IEnumerable<RubroDto> ObtenerTodo();

        bool VerificarSiExiste(long? id, int numero);

        int ObtenerSiguienteNumero();
    }
}
