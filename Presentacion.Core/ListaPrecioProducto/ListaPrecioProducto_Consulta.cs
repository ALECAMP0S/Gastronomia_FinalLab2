using Presentacion.Base;
using Servicio.Core.ListaPrecioProducto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Presentacion.Base.Varios;

namespace Presentacion.Core.ListaPrecioProducto
{
    public partial class ListaPrecioProducto_Consulta : FormularioConsulta
    {
        private readonly IListaPrecioProducto _listaPrecioProducto;

        public ListaPrecioProducto_Consulta()
            :this(new ListaPrecioProductos())
        { 
            InitializeComponent();

        }

        public ListaPrecioProducto_Consulta(IListaPrecioProducto listaPrecioProducto)
        {
            _listaPrecioProducto = listaPrecioProducto;
        }
        public override void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _listaPrecioProducto.ObtenerTodo();
            FormatearGrilla(dgvGrilla);

        }

        public override void FormatearGrilla(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);

            dgvGrilla.Columns["ListaPrecioStr"].Visible = true;
            dgvGrilla.Columns["ListaPrecioStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["ListaPrecioStr"].HeaderText = @"Lista";
            dgvGrilla.Columns["ListaPrecioStr"].DisplayIndex = 1;


            dgvGrilla.Columns["ProductoStr"].Visible = true;
            dgvGrilla.Columns["ProductoStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["ProductoStr"].HeaderText = @"Producto";
            dgvGrilla.Columns["ProductoStr"].DisplayIndex = 2;

            dgvGrilla.Columns["PrecioCosto"].Visible = true;
            dgvGrilla.Columns["PrecioCosto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["PrecioCosto"].HeaderText = @"Precio Costo";
            dgvGrilla.Columns["PrecioCosto"].DisplayIndex = 3;
            dgvGrilla.Columns["PrecioCosto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGrilla.Columns["PrecioCosto"].DefaultCellStyle.Format = "C2";

            dgvGrilla.Columns["PrecioPublico"].Visible = true;
            dgvGrilla.Columns["PrecioPublico"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["PrecioPublico"].HeaderText = @"Precio Publico";
            dgvGrilla.Columns["PrecioPublico"].DisplayIndex = 4;
            dgvGrilla.Columns["PrecioPublico"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGrilla.Columns["PrecioPublico"].DefaultCellStyle.Format = "C2";

            dgvGrilla.Columns["Alicuota"].Visible = true;
            dgvGrilla.Columns["Alicuota"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Alicuota"].HeaderText = @"Alicuota";
            dgvGrilla.Columns["Alicuota"].DisplayIndex = 5;
            dgvGrilla.Columns["Alicuota"].DefaultCellStyle.Format = "P2";
            dgvGrilla.Columns["Alicuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvGrilla.Columns["Fecha"].Visible = true;
            dgvGrilla.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Fecha"].HeaderText = @"Fecha";
            dgvGrilla.Columns["Fecha"].DisplayIndex = 6;
        }
        public override void btnNuevo_Click(object sender, EventArgs e)
        {
            var formualrioNuevo = new ABM_ListaPrecioProducto(Constante.TipoOperacion.Nuevo, null);
            formualrioNuevo.ShowDialog();
            base.btnNuevo_Click(sender, e);
        }

        public override void btnModificar_Click(object sender, EventArgs e)
        {
            var formularioModificar = new ABM_ListaPrecioProducto(Constante.TipoOperacion.Modificar, EntidadId).ShowDialog();
            base.btnModificar_Click(sender, e);
        }
        public override void btnEliminar_Click(object sender, EventArgs e)
        {
            var formularioEliminar = new ABM_ListaPrecioProducto(Constante.TipoOperacion.Eliminar, EntidadId).ShowDialog();
            base.btnModificar_Click(sender, e);
        }
    }
}
