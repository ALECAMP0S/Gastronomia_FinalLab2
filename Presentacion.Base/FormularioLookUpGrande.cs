using System;
using System.Windows.Forms;
using Presentacion.Base.Varios;

namespace Presentacion.Base
{
    public partial class FormularioLookUpGrande : FormularioBase
    {
        private bool puedeEjecutarComando;
        public object Entidad { get; set; }

        public FormularioLookUpGrande()
        {
            InitializeComponent();

            // Color cuando recibe o pierde el foco
            this.txtBuscar.Leave += new EventHandler(this.txt_Leave);
            this.txtBuscar.Enter += new EventHandler(this.txt_Enter);

            this.puedeEjecutarComando = false;

            this.btnSalir.Image = Constante.ImagenControl.BotonSalir;
            this.imgBuscar.Image = Constante.ImagenControl.Buscar;

            this.lblUsuarioLogin.Text = string.Format("Usuario: {0}", Identidad.Empleado);
        }

        public virtual void ActualizarDatos(string cadenaBuscar)
        {

        }

        private void dgvGrilla_DataSourceChanged(object sender, EventArgs e)
        {
            this.puedeEjecutarComando = this.dgvGrilla.RowCount > 0;
        }
        
        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.EntidadId = this.dgvGrilla.RowCount > 0 ? Convert.ToInt64(this.dgvGrilla["Id", e.RowIndex].Value) : (long?)null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(this.txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual object ObtenerEntidad(long entidadId)
        {
            return null;
        }

        private void dgvGrilla_Click(object sender, EventArgs e)
        {
            if(!puedeEjecutarComando) return;

            Entidad = ObtenerEntidad(this.EntidadId.Value);
            this.Close();
        }
    }
}
