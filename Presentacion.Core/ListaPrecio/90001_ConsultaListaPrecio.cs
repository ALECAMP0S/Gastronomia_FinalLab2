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
using Presentacion.Core.Empleado;
using Servicio.Core.Empleado;
using Servicio.Core.ListaPprecio;

namespace Presentacion.Core.ListaPrecio
{
    public partial class _90001_ConsultaListaPrecio : FormularioConsulta
    {
        private readonly IListaPrecioServicio _listaPrecioServicio;
        public _90001_ConsultaListaPrecio()
            :this(new ListaPrecioServicio())
        {


            Titulo = "Lista de Lista de Precios";

        }

        public _90001_ConsultaListaPrecio(IListaPrecioServicio listaPrecioServicio)
        {
            _listaPrecioServicio = listaPrecioServicio;
        }
        public override void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _listaPrecioServicio.ObtenerPorFiltro(cadenaBuscar);

            FormatearGrilla(dgvGrilla);
        }
        public override void FormatearGrilla(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);

            dgvGrilla.Columns["Codigo"].Visible = true;
            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        public override bool EjecutarComandoNuevo()
        {
            var formulario = new _90002_ABM_ListaPrecio(Constante.TipoOperacion.Nuevo, null);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
        public override bool EjecutarComandoModificar()
        {
            var formulario = new _90002_ABM_ListaPrecio(Constante.TipoOperacion.Modificar, EntidadId);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
        public override bool EjecutarComandoEliminar()
        {
            var formulario = new _90002_ABM_ListaPrecio(Constante.TipoOperacion.Eliminar, EntidadId);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
    }
}
