using System.Windows.Forms;
using Presentacion.Base;
using Presentacion.Base.Varios;
using Servicio.Core.Mesa;

namespace Presentacion.Core.Mesa
{
    public partial class _00001_ConsultaMesas : FormularioConsulta
    {
        private readonly IMesaServicio _mesaServicio;

        public _00001_ConsultaMesas()
            : this(new MesaServicio())
        {
            Titulo = "Lista de Mesas";
        }

        public _00001_ConsultaMesas(IMesaServicio mesaServicio)
        {
            InitializeComponent();
            _mesaServicio = mesaServicio;
        }

        public override void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _mesaServicio.ObtenerPorFiltro(cadenaBuscar);

           FormatearGrilla(dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);

            dgvGrilla.Columns["Numero"].Visible = true;
            dgvGrilla.Columns["Numero"].Width = 100;
            dgvGrilla.Columns["Numero"].HeaderText = @"Número";

            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Descripcion"].HeaderText = @"Descripción";

            dgvGrilla.Columns["EstadoMesa"].Visible = true;
            dgvGrilla.Columns["EstadoMesa"].Width = 100;
            dgvGrilla.Columns["EstadoMesa"].HeaderText = @"Estado";
        }

        public override bool EjecutarComandoNuevo()
        {
            var formulario = new _00002_ABM_Mesa(Constante.TipoOperacion.Nuevo,null);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }

        public override bool EjecutarComandoModificar()
        {
            var formulario = new _00002_ABM_Mesa(Constante.TipoOperacion.Modificar, EntidadId);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }

        public override bool EjecutarComandoEliminar()
        {
            var formulario = new _00002_ABM_Mesa(Constante.TipoOperacion.Eliminar, EntidadId);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
    }
}
