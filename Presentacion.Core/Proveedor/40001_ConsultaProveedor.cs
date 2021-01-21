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
using Servicio.Core.Proveedor;

namespace Presentacion.Core.Proveedor
{
    public partial class _40001_ConsultaProveedor : FormularioConsulta
    {
        private readonly IProveedorServicio _proveedorServicio;
        public _40001_ConsultaProveedor()
           : this(new ProveedorServicio())
        {
            InitializeComponent();

            Titulo = "Lista de Proveedores";

        }
        public _40001_ConsultaProveedor(IProveedorServicio proveedorServicio)
        {
            _proveedorServicio = proveedorServicio;
        }

        public override void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _proveedorServicio.ObtenerPorFiltro(cadenaBuscar);

            FormatearGrilla(dgvGrilla);
        }
        public override void FormatearGrilla(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);

            dgvGrilla.Columns["ApyNomContacto"].Visible = true;
            dgvGrilla.Columns["ApyNomContacto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["ApyNomContacto"].HeaderText = @"Apellido y Nombre";

            dgvGrilla.Columns["NombreFantacia"].Visible = true;
            dgvGrilla.Columns["NombreFantacia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["NombreFantacia"].HeaderText = @"Nombre Fantasia";
            dgvGrilla.Columns["Cuil"].Visible = true;

        }
        public override bool EjecutarComandoNuevo()
        {
            var formulario = new _40002_ABM_Proveedor(Constante.TipoOperacion.Nuevo, null);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
        public override bool EjecutarComandoModificar()
        {
            var formulario = new _40002_ABM_Proveedor(Constante.TipoOperacion.Modificar, EntidadId);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
        public override bool EjecutarComandoEliminar()
        {
            var formulario = new _40002_ABM_Proveedor(Constante.TipoOperacion.Eliminar, EntidadId);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
    }
}
