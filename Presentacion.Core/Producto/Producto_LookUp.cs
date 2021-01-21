using System;
using System.Linq;
using Presentacion.Base;
using Servicio.Core.Producto;
using System.Windows.Forms;

namespace Presentacion.Core.Producto
{
    public partial class Producto_LookUp : FormularioLookUp
    {
        private long _listaPrecioId;
        private IProductoServicio _productoServicio;

        public Producto_LookUp()
        {
            InitializeComponent();
            _productoServicio = new ProductoServicio();
        }

        public Producto_LookUp(long listaPrecioId)
            :this()
        {
            _listaPrecioId = listaPrecioId;
        }

        private void Producto_LookUp_Load(object sender, System.EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }

        public override void ActualizarDatos(string cadenaBuscar)
        {
            var productos = _productoServicio.ObtenerPorListaPrecio(_listaPrecioId, cadenaBuscar);
            dgvGrilla.DataSource = productos.ToList();
        }

        private void txtBuscar_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ActualizarDatos(txtBuscar.Text);
            }
        }

        private void btnBuscar_TextChanged(object sender, EventArgs e)
        {
           
                ActualizarDatos(txtBuscar.Text);
            
        }
    }
}
