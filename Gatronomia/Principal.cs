using Presentacion.Core.Mesa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.Core.Cliente;
using Presentacion.Core.Empleado;
using Presentacion.Core.ListaPrecio;
using Presentacion.Core.Marca;
using Presentacion.Core.Producto;
using Presentacion.Core.Proveedor;
using Presentacion.Core.Rubro;
using Presentacion.Core.SubRubro;
using Presentacion.Core.Venta_en_Salon;
using Presentacion.Core.CuentaCorriente;
using Presentacion.Core.Cadeteria;
using Presentacion.Core.ListaPrecioProducto;

namespace Gatronomia
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        //MENU ADMINISTRACION
        private void nuevaMesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _00001_ConsultaMesas().ShowDialog();
        }

        private void nuevoEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _20001_ConsultaEmpleados().ShowDialog();
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _30001_ConsultaCliente().ShowDialog();
        }

        private void nuevoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _40001_ConsultaProveedor().ShowDialog();
        }

        //SALON

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _10001_VentaSalon().ShowDialog();
        }

        //DELIVERY

        private void nuevoDeliveryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new _100001_Cadeteria().ShowDialog();
        }

        // MENU PRODUCTO
        
        private void nuevaMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _50001_ConsultaMarca().ShowDialog();
        }

        private void nuevoRubroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _60001_ConsultaRubro().ShowDialog();
        }

        private void nuevoRubroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new _70001_ConsultaSubRubro().ShowDialog();
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _80001_ConsultaProducto().ShowDialog();
        }

        private void nuevaListaDePrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _90001_ConsultaListaPrecio().ShowDialog();
        }

        private void consultaToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            new ListaPrecioProducto_Consulta().ShowDialog();
        }
    }
}

