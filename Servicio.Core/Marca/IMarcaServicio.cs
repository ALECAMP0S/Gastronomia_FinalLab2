using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.Marca
{
    public interface IMarcaServicio
    {
        void Insertar(MarcaDto dto);

        void Modificar(MarcaDto dto);

        void Eliminar(MarcaDto dto);

        MarcaDto ObtenerPorId(long id);
        IEnumerable<MarcaDto> ObtenerPorFiltro(string cadenaBuscar);
        IEnumerable<MarcaDto> ObtenerTodo();

        bool VerificarSiExiste(long? id, int numero);

        int ObtenerSiguienteNumero();
    }
}
