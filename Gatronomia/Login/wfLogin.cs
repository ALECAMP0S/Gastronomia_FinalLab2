using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.Base;
using Presentacion.Base.Varios;
using Presentacion.Core.Usuario;

namespace Gatronomia.Login
{
    public partial class wfLogin : FormularioBase
    {
        private readonly IUsuarioServicio _usuarioServicio;
        public wfLogin()
        {
            InitializeComponent();
            _usuarioServicio = new UsuarioServicio();

            txtUsuario.KeyPress += Validacion.NoNumeros;
            txtUsuario.KeyPress += Validacion.NoSimbolos;
        }
        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            if (_usuarioServicio.Autenticar(txtPassword.Text, txtUsuario.Text))
            {
                // Autenticado
                Mensaje.Mostrar("Bienvenido " + txtUsuario.Text, Mensaje.Tipo.Informacion);
                Hide();
                new Principal().ShowDialog();
                Close();
            }
            else
            {
                Mensaje.Mostrar("El usuario o la Contraseña no Existen.", Mensaje.Tipo.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void wfLogin_Load_1(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
