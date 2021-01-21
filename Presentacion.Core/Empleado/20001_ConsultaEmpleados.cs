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
using Servicio.Core.Empleado;
using Presentacion.Base.Varios;

namespace Presentacion.Core.Empleado
{
    public partial class _20001_ConsultaEmpleados : FormularioConsulta
    {
        private readonly IEmpleadoServicio _empleadoServicio;
        public _20001_ConsultaEmpleados()
            :this(new EmpleadoServicio())
        {


            Titulo = "Lista de Empleados";

        }

        public _20001_ConsultaEmpleados(IEmpleadoServicio empleadoServicio)
        {
            _empleadoServicio = empleadoServicio;
        }
        public override void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _empleadoServicio.ObtenerPorFiltro(cadenaBuscar);

            FormatearGrilla(dgvGrilla);
        }
        public override void FormatearGrilla(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);

            dgvGrilla.Columns["Legajo"].Visible = true;
            dgvGrilla.Columns["Apellido"].Visible = true;
            dgvGrilla.Columns["Apellido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Nombre"].Visible = true;
            dgvGrilla.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["TipoEmpleado"].Visible = true;
            dgvGrilla.Columns["Dni"].Visible = true;

        }
        public override bool EjecutarComandoNuevo()
        {
            var formulario = new _20002_ABM_Empleado(Constante.TipoOperacion.Nuevo, null);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
        public override bool EjecutarComandoModificar()
        {
            var formulario = new _20002_ABM_Empleado(Constante.TipoOperacion.Modificar, EntidadId);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
        public override bool EjecutarComandoEliminar()
        {
            var formulario = new _20002_ABM_Empleado(Constante.TipoOperacion.Eliminar, EntidadId);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
    }
}
