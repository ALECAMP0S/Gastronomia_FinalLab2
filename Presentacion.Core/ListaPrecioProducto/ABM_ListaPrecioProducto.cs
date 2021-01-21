using Presentacion.Base;
using Presentacion.Base.Varios;
using Servicio.Core.ListaPprecio;
using Servicio.Core.ListaPrecioProducto;
using Servicio.Core.Producto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.ListaPrecioProducto
{
    public partial class ABM_ListaPrecioProducto : FormularioABM
    {
        private readonly IProductoServicio _productoServicio;
        private readonly IListaPrecioProducto _listaPrecioProducto;
        private readonly IListaPrecioServicio _listaPrecio;
        public ABM_ListaPrecioProducto(string _tipoOperacion, long? _entidadid = null)
            : base(_tipoOperacion, _entidadid)
        {
            InitializeComponent();
            _productoServicio = new ProductoServicio();
            _listaPrecioProducto = new ListaPrecioProductos();
            _listaPrecio = new ListaPrecioServicio();
            Init(_tipoOperacion, _entidadid);
        }

        private void ABM_ListaPrecioProducto_Load(object sender, EventArgs e)
        {
            CargarCmbs();
        }

        private void CargarCmbs()
        {
            cmbProducto.DataSource = _productoServicio.ObtenerTodo();
            cmbProducto.DisplayMember = "Descripcion";
            cmbProducto.ValueMember = "Codigo";


            cmdLista.DataSource = _listaPrecio.Obtener();
            cmdLista.DisplayMember = "Descripcion";
            cmdLista.ValueMember = "Codigo";
        }
        public override bool EjecutarComandoNuevo()
        {
            try
            {
                var listanueva = new ListaPrecioProductoDto()
                {
                    ListaPrecioId = ((ListaPrecioDto)cmdLista.SelectedItem).Id,
                    ProductoId = ((ProductoDto)cmbProducto.SelectedItem).Id,
                    ProductoStr = ((ProductoDto)cmbProducto.SelectedItem).Descripcion,
                    ListaPrecioStr = ((ListaPrecioDto)cmdLista.SelectedItem).Descripcion,
                    PrecioCosto = nudPrecioCosto.Value,
                    PrecioPublico = nudPrecioCosto.Value + (nudPrecioCosto.Value * 0.21m),
                    Fecha = dateTimePicker1.Value
                };
                _listaPrecioProducto.CrearListaPrecioProducto(listanueva);
                Mensaje.Mostrar("Los datos se grabaron correctamente", Mensaje.Tipo.Informacion);
                return true;
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(ex.Message, Mensaje.Tipo.Stop);
            }
            return false;
        }
        public override bool EjecutarComandoModificar()
        {
            try
            {
                var listaid = ((ListaPrecioDto)cmdLista.SelectedItem).Id;
                var productoid = ((ProductoDto)cmbProducto.SelectedItem).Id;
                var mod = new ListaPrecioProductoDto
                {
                    Id = entidadId.Value,
                    ListaPrecioId = listaid,
                    ProductoId = productoid,

                    PrecioCosto = nudPrecioCosto.Value,
                    PrecioPublico = nudPrecioCosto.Value +(nudPrecioCosto.Value * 0.21m),
                    Fecha = dateTimePicker1.Value

                };
                _listaPrecioProducto.Modificar(mod);
                Mensaje.Mostrar("Los datos se modificaron correctamente", Mensaje.Tipo.Informacion);
                return true;
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(ex.Message, Mensaje.Tipo.Stop);
                return false;
            }
        }
        public override bool EjecutarComandoEliminar()
        {
            try
            {
                _listaPrecioProducto.Eliminar(_listaPrecioProducto.ObtenerPorId((long)entidadId));
                Mensaje.Mostrar("Los datos se eliminaron correctamente", Mensaje.Tipo.Informacion);
                return true;
            }
            catch (Exception ex)
            {

                Mensaje.Mostrar(ex.Message, Mensaje.Tipo.Stop);
                return false;
            }
        }


        private void nudPrecioCosto_ValueChanged(object sender, EventArgs e)
        {
            txtPrecioPublico.Text = (nudPrecioCosto.Value + (nudPrecioCosto.Value*0.21m)).ToString("C2");

        }
    }
}
