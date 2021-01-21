using System;
using System.Windows.Forms;
using Presentacion.Base.Varios;

namespace Presentacion.Base
{
    public partial class FormularioLookUpConDobleDetalle : FormularioBase
    {
        private bool puedeEjecutarComando;
        public object Entidad { get; set; }

        public FormularioLookUpConDobleDetalle()
        {
            InitializeComponent();

            this.puedeEjecutarComando = false;
            this.btnSalir.Image = Constante.ImagenControl.BotonSalir;

            this.lblUsuarioLogin.Text = string.Format("Usuario: {0}", Identidad.Empleado);
        }

        public virtual void ActualizarDatos(string cadenaBuscar)
        {

        }

        private void dgvGrilla_DataSourceChanged(object sender, EventArgs e)
        {
            this.puedeEjecutarComando = this.dgvGrilla.RowCount > 0;
        }

        public virtual void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Entidad = this.dgvGrilla.RowCount > 0 ? dgvGrilla.Rows[e.RowIndex].DataBoundItem : null;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvGrilla_DoubleClick(object sender, EventArgs e)
        {
            if (!puedeEjecutarComando) return;
            this.Close();
        }

        private void FormularioLookUp_Load(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
