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
using Servicio.Core.Rubro;

namespace Presentacion.Core.Rubro
{
    public partial class _60001_ConsultaRubro : FormularioConsulta
    {
        private readonly IRubroServicio _rubroServicio;
        public _60001_ConsultaRubro()
            : this(new RubroServicio())
        {
            Titulo = "Lista de Rubros";
        }

        public _60001_ConsultaRubro(IRubroServicio rubroServicio)
        {
            InitializeComponent();
            _rubroServicio = rubroServicio;
        }
        public override void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _rubroServicio.ObtenerPorFiltro(cadenaBuscar);

            FormatearGrilla(dgvGrilla);
        }
        public override void FormatearGrilla(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);

            dgvGrilla.Columns["Codigo"].Visible = true;
            dgvGrilla.Columns["Codigo"].Width = 100;
            dgvGrilla.Columns["Codigo"].HeaderText = @"Número";

            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Descripcion"].HeaderText = @"Descripción";
        }
        public override bool EjecutarComandoNuevo()
        {
            var formulario = new _60002_ABM_Rubro(Constante.TipoOperacion.Nuevo, null);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
        public override bool EjecutarComandoModificar()
        {
            var formulario = new _60002_ABM_Rubro(Constante.TipoOperacion.Modificar, EntidadId);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }

        public override bool EjecutarComandoEliminar()
        {
            var formulario = new _60002_ABM_Rubro(Constante.TipoOperacion.Eliminar, EntidadId);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
    }
}
