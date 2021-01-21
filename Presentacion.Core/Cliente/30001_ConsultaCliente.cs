using Servicio.Core.Cliente;
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
using Presentacion.Core.CuentaCorriente;

namespace Presentacion.Core.Cliente
{
    public partial class _30001_ConsultaCliente : FormularioConsulta
    {
        private readonly IClienteServicio _clienteServicio;
        public _30001_ConsultaCliente()
            : this(new ClienteServicio())
        {
            InitializeComponent();
            Titulo = "Lista de Clientes";
        }

        public _30001_ConsultaCliente(IClienteServicio clienteServicio)
        {
            _clienteServicio = clienteServicio;
        }
        public override void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _clienteServicio.ObtenerPorFiltro(cadenaBuscar);

            FormatearGrilla(dgvGrilla);
        }
        public override void FormatearGrilla(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);

            dgvGrilla.Columns["Codigo"].Visible = true;
            dgvGrilla.Columns["Apellido"].Visible = true;
            dgvGrilla.Columns["Apellido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Nombre"].Visible = true;
            dgvGrilla.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Dni"].Visible = true;
            dgvGrilla.Columns["TieneCtaCte"].Visible = true;
            dgvGrilla.Columns["MontoMaximoCtaCte"].Visible = true;


        }
        public override bool EjecutarComandoNuevo()
        {
            var formulario = new _30002_ABM_Cliente(Constante.TipoOperacion.Nuevo, null);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
        public override bool EjecutarComandoModificar()
        {
            var formulario = new _30002_ABM_Cliente(Constante.TipoOperacion.Modificar, EntidadId);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
        public override bool EjecutarComandoEliminar()
        {
            var formulario = new _30002_ABM_Cliente(Constante.TipoOperacion.Eliminar, EntidadId);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }

        private void btnCtaCte_Click(object sender, EventArgs e)
        {
            if (EntidadId == null)
            {
                Mensaje.Mostrar("Elija un cliente", Mensaje.Tipo.Informacion);
            }
            else
            {
                var formulario = new _30003_CtaCte_Cliente(EntidadId);
                formulario.ShowDialog();
            }
            
        }
    }
}
