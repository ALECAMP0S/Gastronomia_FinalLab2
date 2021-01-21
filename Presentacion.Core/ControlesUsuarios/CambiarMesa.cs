using Presentacion.Base;
using Servicio.Core.Mesa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.ControlesUsuarios
{
    public partial class CambiarMesa : FormularioBase
    {
        public long _mesaId;
        public bool realizoAlgunaOperacion;
        private readonly IMesaServicio _mesaServicio;
        
        public CambiarMesa(long mesaId)
            : this(new MesaServicio())
        {
            InitializeComponent();
            realizoAlgunaOperacion = false;
        }
        public CambiarMesa(IMesaServicio mesaServicio)
        {
            _mesaServicio = mesaServicio;
        }
        private void CambiarMesa_Load(object sender, EventArgs e)
        {
            PoblarComboBox(cmbDestino, _mesaServicio.ObtenerTodo(), "Descripcion", "Id");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _mesaId = (long)cmbDestino.SelectedValue;
            realizoAlgunaOperacion = true;
            Close();
        }
    }
}
