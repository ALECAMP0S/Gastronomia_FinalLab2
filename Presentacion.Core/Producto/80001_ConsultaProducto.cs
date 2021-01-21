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
using Servicio.Core.Producto;
using Presentacion.Base.Varios;

namespace Presentacion.Core.Producto
{
    public partial class _80001_ConsultaProducto : FormularioConsulta
    {
        private readonly IProductoServicio _productoServicio;
        public _80001_ConsultaProducto()
            : this(new ProductoServicio())

        {
            Titulo = "Lista de Productos";
        }

        public _80001_ConsultaProducto(IProductoServicio productoServicio)
        {
            InitializeComponent();
            _productoServicio = productoServicio;
        }
        public override void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _productoServicio.ObtenerPorFiltro(cadenaBuscar);

            FormatearGrilla(dgvGrilla);
        }
        public override void FormatearGrilla(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);

            dgvGrilla.Columns["Codigo"].Visible = true;
            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Stock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Stock"].Visible = true;
            dgvGrilla.Columns["CodigoBarra"].Visible = true;

        }
        public override bool EjecutarComandoNuevo()
        {
            var formulario = new _80002_ABM_Producto(Constante.TipoOperacion.Nuevo, null);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
        public override bool EjecutarComandoModificar()
        {
            var formulario = new _80002_ABM_Producto(Constante.TipoOperacion.Modificar, EntidadId);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
        public override bool EjecutarComandoEliminar()
        {
            var formulario = new _80002_ABM_Producto(Constante.TipoOperacion.Eliminar, EntidadId);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
    }
}
