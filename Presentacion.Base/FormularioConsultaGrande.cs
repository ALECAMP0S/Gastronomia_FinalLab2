using System;
using System.Windows.Forms;
using Presentacion.Base.Varios;
using System.Threading;

namespace Presentacion.Base
{
    public partial class FormularioConsultaGrande : FormularioBase
    {
        private bool puedeEjecutarComando;

        public string Titulo
        {
            set { lblTitulo.Text = value; }
        }

        public FormularioConsultaGrande()
        {
            InitializeComponent();

            // Color cuando recibe o pierde el foco
            this.txtBuscar.Leave += new EventHandler(this.txt_Leave);
            this.txtBuscar.Enter += new EventHandler(this.txt_Enter);

            this.puedeEjecutarComando = false;

            this.btnNuevo.Image = Constante.ImagenControl.BotonNuevo;
            this.btnEliminar.Image = Constante.ImagenControl.BotonEliminar;
            this.btnModificar.Image = Constante.ImagenControl.BotonModificar;
            this.btnActualizar.Image = Constante.ImagenControl.BotonActualizar;
            this.btnImprimir.Image = Constante.ImagenControl.BotonImprimir;
            this.btnSalir.Image = Constante.ImagenControl.BotonSalir;

            this.imgBuscar.Image = Constante.ImagenControl.Buscar;
            this.lblUsuarioLogin.Image = Constante.ImagenControl.Usuario;
            lblUsuarioLogin.Text = Identidad.UsuarioLogin;
            this.lblUsuarioLogin.Text = string.Format("Usuario: {0}", Identidad.Empleado);
        }

        public virtual  void btnNuevo_Click(object sender, EventArgs e)
        {
            if (EjecutarComandoNuevo())
            {
                ActualizarDatos(string.Empty);
            }
        }

        public virtual void btnEliminar_Click(object sender, EventArgs e)
        {
            if (puedeEjecutarComando)
            {
                if (EjecutarComandoEliminar())
                {
                    ActualizarDatos(string.Empty);
                }
            }
            else
            {
                Mensaje.Mostrar(Constante.Mensaje.NoHayDatosCargados, Mensaje.Tipo.Informacion);
            }
        }

        public virtual void btnModificar_Click(object sender, EventArgs e)
        {
            if (puedeEjecutarComando)
            {
                if (EjecutarComandoModificar())
                {
                    ActualizarDatos(string.Empty);
                }
            }
            else
            {
                Mensaje.Mostrar(Constante.Mensaje.NoHayDatosCargados, Mensaje.Tipo.Informacion);
            }
        }
        
        public virtual void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }        

        public virtual void btnImprimir_Click(object sender, EventArgs e)
        {
            if (puedeEjecutarComando)
            {
                EjecutarComandoImprimir();
            }
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

        public virtual bool EjecutarComandoNuevo()
        {
            return true;
        }

        public virtual bool EjecutarComandoModificar()
        {
            return true;
        }
        
        public virtual bool EjecutarComandoEliminar()
        {
            return true;
        }

        public virtual bool EjecutarComandoImprimir()
        {
            return true;
        }

        public virtual void dgvGrilla_DataSourceChanged(object sender, EventArgs e)
        {
            this.puedeEjecutarComando = this.dgvGrilla.RowCount > 0;
        }

        private void FormularioConsultaGrande_Load(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }
    }
}
