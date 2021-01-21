using Presentacion.Base;
using Servicio.Core.Cliente;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Core.Cliente
{
    public partial class Cliente_LookUp : FormularioLookUp
    {
        private IClienteServicio _clienteServicio;


        public Cliente_LookUp()
        {
            _clienteServicio = new ClienteServicio();

            InitializeComponent();
        }
        private void Cliente_LookUp_Load(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }
        public override void ActualizarDatos(string cadenaBuscar)
        {

            var productos = _clienteServicio.ObtenerPorFiltro(cadenaBuscar);
            dgvGrilla.DataSource = productos.ToList();
        }
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
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
