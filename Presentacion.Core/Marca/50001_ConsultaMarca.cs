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
using Servicio.Core.Marca;
using Presentacion.Base.Varios;

namespace Presentacion.Core.Marca
{
    public partial class _50001_ConsultaMarca : FormularioConsulta
    {
        private readonly IMarcaServicio _marcaServicio;
        public _50001_ConsultaMarca()
            : this(new MarcaServicio())
        {

            Titulo = "Lista de Marcas";
        }

        public _50001_ConsultaMarca(IMarcaServicio marcaServicio)
        {
            InitializeComponent();
            _marcaServicio = marcaServicio;
        }
        public override void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _marcaServicio.ObtenerPorFiltro(cadenaBuscar);

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
            var formulario = new _50002_ABM_Marca(Constante.TipoOperacion.Nuevo, null);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
        public override bool EjecutarComandoModificar()
        {
            var formulario = new _50002_ABM_Marca(Constante.TipoOperacion.Modificar, EntidadId);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }

        public override bool EjecutarComandoEliminar()
        {
            var formulario = new _50002_ABM_Marca(Constante.TipoOperacion.Eliminar, EntidadId);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
    }
}
