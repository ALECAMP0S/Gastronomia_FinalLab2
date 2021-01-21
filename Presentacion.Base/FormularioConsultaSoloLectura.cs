using System;
using System.Windows.Forms;
using Presentacion.Base.Varios;

namespace Presentacion.Base
{
    public partial class FormularioConsultaSoloLectura : FormularioBase
    {
        public string Titulo {
            set { lblTitulo.Text = value; }
        }

        public FormularioConsultaSoloLectura()
        {
            InitializeComponent();

            // Color cuando recibe o pierde el foco
            this.txtBuscar.Leave += new EventHandler(this.txt_Leave);
            this.txtBuscar.Enter += new EventHandler(this.txt_Enter);

            this.btnActualizar.Image = Constante.ImagenControl.BotonActualizar;
            this.btnSalir.Image = Constante.ImagenControl.BotonSalir;

            this.imgBuscar.Image = Constante.ImagenControl.Buscar;
            this.lblUsuarioLogin.Image = Constante.ImagenControl.Usuario;
            this.lblUsuarioLogin.Text = string.Format("Usuario: {0}", Identidad.Empleado);
        }

        public virtual void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }        

        public virtual void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(this.txtBuscar.Text);
        }
        
        public virtual void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.EntidadId = this.dgvGrilla.RowCount > 0 ? Convert.ToInt64(this.dgvGrilla["Id", e.RowIndex].Value) : (long?)null;
        }

        public virtual void ActualizarDatos(string cadenaBuscar)
        {

        }
        
        public virtual void dgvGrilla_DataSourceChanged(object sender, EventArgs e)
        {
        }
        
        private void FormularioConsultaSoloLectura_Load(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }
    }
}
