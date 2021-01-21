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
using Servicio.Core.SubRubro;
using Presentacion.Base.Varios;

namespace Presentacion.Core.SubRubro
{
    public partial class _70001_ConsultaSubRubro : FormularioConsulta
    {
        private readonly ISubRubroServicio _subRubroServicio;
        public _70001_ConsultaSubRubro()
            : this(new SubRubroServicio())
        {
            Titulo = "Lista de SubRubros";

        }

        public _70001_ConsultaSubRubro(ISubRubroServicio subRubroServicio)
        {
            InitializeComponent();
            _subRubroServicio = subRubroServicio;
        }
        public override void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _subRubroServicio.ObtenerPorFiltro(cadenaBuscar);

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

            //dgvGrilla.Columns["Rubro"].Visible = true;
            //dgvGrilla.Columns["Rubro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvGrilla.Columns["Rubro"].HeaderText = @"Descripción";
        }
        public override bool EjecutarComandoNuevo()
        {
            var formulario = new _70002_ABM_SubRubro(Constante.TipoOperacion.Nuevo, null);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
        public override bool EjecutarComandoModificar()
        {
            var formulario = new _70002_ABM_SubRubro(Constante.TipoOperacion.Modificar, EntidadId);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }

        public override bool EjecutarComandoEliminar()
        {
            var formulario = new _70002_ABM_SubRubro(Constante.TipoOperacion.Eliminar, EntidadId);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
    }
}
