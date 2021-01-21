using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Presentacion.Base;
using Servicio.Core.Empleado;
using Servicio.Core.Producto;

namespace Presentacion.Core.Mozo
{
    public partial class Mozo_LookUp : FormularioLookUp
    {
        private IEmpleadoServicio _empleadoServicio;
        public Mozo_LookUp()
        {
            _empleadoServicio = new EmpleadoServicio();
            InitializeComponent();
        }

        private void Mozo_LookUp_Load(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }
        public override void ActualizarDatos(string cadenaBuscar)
        {
            var productos = _empleadoServicio.ObtenerMozoPorId(cadenaBuscar);
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
