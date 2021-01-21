using Presentacion.Base;
using Servicio.Core.Empleado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Cadeteria
{
    public partial class Cadete_LookUp : FormularioLookUp
    {
        private IEmpleadoServicio _empleadoServicio;

        public Cadete_LookUp()
        {
            _empleadoServicio = new EmpleadoServicio();

            InitializeComponent();
        }

        private void Cadete_LookUp_Load(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);

        }
        public override void ActualizarDatos(string cadenaBuscar)
        {
            var productos = _empleadoServicio.ObtenerCadetePorId(cadenaBuscar);
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
