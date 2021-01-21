using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.Producto
{
    public interface IProductoServicio
    {
        IEnumerable<ProductoDto> ObtenerPorListaPrecio(long listaPrecioId, string cadenBuscar);

        ProductoDto ObtenerPorId(long id);

        ProductoDto ObtenerPorDescripcion(string cadenaBuscar, long listaPrecioId);

        void Modificar(ProductoDto dto);

        void Eliminar(ProductoDto dto);

        IEnumerable<ProductoDto> ObtenerPorFiltro(string cadenaBuscar);

        bool VerificarSiExiste(long? ProductoId, int legajo);

        IEnumerable<ProductoDto> ObtenerTodo();

        int ObtenerSiguienteLegajo();
        void Insertar(ProductoDto productoDto);
    }
}
