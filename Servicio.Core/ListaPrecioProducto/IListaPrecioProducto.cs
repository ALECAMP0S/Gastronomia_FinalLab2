using Servicio.Core.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.ListaPrecioProducto
{
    public interface IListaPrecioProducto
    {
        IEnumerable<ProductoDto> ObtenerLista(string cadenabuscar,long listaid);

        ProductoDto ObtnerProducto(string cadenabuscar, long listaid);

        IEnumerable<ListaPrecioProductoDto> ObtenerTodo();
        ListaPrecioProductoDto ObtenerPorId(long Id);

        void Eliminar(ListaPrecioProductoDto dto);
        void CrearListaPrecioProducto(ListaPrecioProductoDto lista);

        void Modificar(ListaPrecioProductoDto dto);
        ListaPrecioProductoDto ObtenerListaPorProductoId(long Id);

    }
}
