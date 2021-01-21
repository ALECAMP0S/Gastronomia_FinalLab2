using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Servicio.Core.ListaPprecio
{
    public interface IListaPrecioServicio
    {
        IEnumerable<ListaPrecioDto> Obtener();

        ListaPrecioDto ObtenerPorLegajo(string cadenaBuscar);

        void Insertar(ListaPrecioDto dto);

        void Modificar(ListaPrecioDto dto);

        void Eliminar(ListaPrecioDto dto);

        ListaPrecioDto ObtenerPorId(long id);
        IEnumerable<ListaPrecioDto> ObtenerPorFiltro(string cadenaBuscar);

        bool VerificarSiExiste(long? empleadoId, int legajo);

        int ObtenerSiguienteLegajo();
    }
}
