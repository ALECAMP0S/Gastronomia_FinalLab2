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
using Presentacion.Base;
using Servicio.Core.Empleado;
using Presentacion.Base.Varios;

namespace Presentacion.Core.Empleado
{
    public partial class _20002_ABM_Empleado : FormularioABM
    {
        private readonly IEmpleadoServicio _empleadoServicio;

        public _20002_ABM_Empleado()
        {
            InitializeComponent();
        }

        public _20002_ABM_Empleado(string _tipoOperacion, long? _entidadId = default(long?))
            : base(_tipoOperacion, _entidadId)
        {

            InitializeComponent();
            _empleadoServicio = new EmpleadoServicio();

            nudLegajo.Enter += txt_Enter;
            nudLegajo.Leave += txt_Leave;

            txtNombre.Enter += txt_Enter;
            txtNombre.Leave += txt_Leave;
            txtNombre.KeyPress += Validacion.NoSimbolos;
            txtNombre.KeyPress += Validacion.NoInyeccion;
            txtNombre.KeyPress += Validacion.NoNumeros;

            txtApellido.Enter += txt_Enter;
            txtApellido.Leave += txt_Leave;
            txtApellido.KeyPress += Validacion.NoSimbolos;
            txtApellido.KeyPress += Validacion.NoInyeccion;
            txtApellido.KeyPress += Validacion.NoNumeros;

            txtTelefono.Enter += txt_Enter;
            txtTelefono.Leave += txt_Leave;
            txtTelefono.KeyPress += Validacion.NoSimbolos;
            txtTelefono.KeyPress += Validacion.NoInyeccion;
            txtTelefono.KeyPress += Validacion.NoLetras;

            txtCelular.Enter += txt_Enter;
            txtCelular.Leave += txt_Leave;
            txtCelular.KeyPress += Validacion.NoSimbolos;
            txtCelular.KeyPress += Validacion.NoInyeccion;
            txtCelular.KeyPress += Validacion.NoLetras;

            txtDni.Enter += txt_Enter;
            txtDni.Leave += txt_Leave;
            txtDni.KeyPress += Validacion.NoSimbolos;
            txtDni.KeyPress += Validacion.NoInyeccion;
            txtDni.KeyPress += Validacion.NoLetras;


            txtCuil.Enter += txt_Enter;
            txtCuil.Leave += txt_Leave;
            txtCuil.KeyPress += Validacion.NoSimbolos;
            txtCuil.KeyPress += Validacion.NoInyeccion;
            txtCuil.KeyPress += Validacion.NoLetras;

            Init(_tipoOperacion, entidadId);
        }
        public override void LimpiarDatos(object obj)
        {
            base.LimpiarDatos(obj);
            ObtenerSiguienteCodigo();
        }
        private void ObtenerSiguienteCodigo()
        {
            nudLegajo.Value = _empleadoServicio.ObtenerSiguienteLegajo();
        }
        public override void CargarDatos(long? entidadId)
        {
            try
            {
                var empleado = _empleadoServicio.ObtenerPorId(entidadId.Value);

                txtApellido.Text = empleado.Apellido;
                txtDireccion.Text = empleado.Direccion;
                txtDni.Text = empleado.Dni;
                txtNombre.Text = empleado.Nombre;
                txtTelefono.Text = empleado.Telefono;
                nudLegajo.Value = empleado.Legajo;
                txtCuil.Text = empleado.Cuil;
                txtCelular.Text = empleado.Celular;
                cmbTipoEmpleado.SelectedIndex = (int)empleado.TipoEmpleado;

                nudLegajo.Focus();
            }
            catch (ArgumentNullException exNull)
            {
                Mensaje.Mostrar("Hubo un error", Mensaje.Tipo.Informacion);
                nudLegajo.Focus();
            }

        }
        public override bool EjecutarComandoNuevo()
        {
            try
            {
                _empleadoServicio.Insertar(new EmpleadoDto
                {
                    Nombre = txtNombre.Text,
                    Legajo = (int)nudLegajo.Value,
                    Dni = txtDni.Text,
                    Apellido = txtApellido.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Celular = txtCelular.Text,
                    Cuil = txtCuil.Text,
                    TipoEmpleado = ((TipoEmpleado)cmbTipoEmpleado.SelectedIndex + 1)

                });

                Mensaje.Mostrar("Los datos se grabaron Correctamente.", Mensaje.Tipo.Informacion);
                return true;
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar("Hubo un error al cargar los datos", Mensaje.Tipo.Error);
            }
            return false;
        }
        public override bool EjecutarComandoModificar()
        {
            try
            {
                if (!VerificarSiExiste(entidadId.Value, (int)nudLegajo.Value))
                {
                    _empleadoServicio.Modificar(new EmpleadoDto
                    {
                        Id = entidadId.Value,
                        Nombre = txtNombre.Text,
                        Legajo = (int)nudLegajo.Value,
                        Dni = txtDni.Text,
                        Apellido = txtApellido.Text,
                        Direccion = txtDireccion.Text,
                        Telefono = txtTelefono.Text,
                        Celular = txtCelular.Text,
                        Cuil = txtCuil.Text,
                        TipoEmpleado = ((TipoEmpleado)cmbTipoEmpleado.SelectedIndex + 1)
                    });

                    Mensaje.Mostrar("Los datos se grabaron Correctamente.", Mensaje.Tipo.Informacion);
                    return true;
                }
                else
                {
                    Mensaje.Mostrar("Los datos cargados ya existen.", Mensaje.Tipo.Advertencia);
                }

            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(ex.Message, Mensaje.Tipo.Error);
            }
            return false;
        }
        public override bool EjecutarComandoEliminar()
        {
            try
            {
                _empleadoServicio.Eliminar(new EmpleadoDto
                {
                    Id = entidadId.Value,
                    EstaBloqueado = false,
                    EstaEliminado = false

                });

                Mensaje.Mostrar("Los datos se eliminaron Correctamente.", Mensaje.Tipo.Informacion);
                return true;
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(ex.Message, Mensaje.Tipo.Error);
            }
            return false;
        }
        private bool VerificarSiExiste(long? empleadoId, int legajo)
        {
            return _empleadoServicio.VerificarSiExiste(empleadoId, legajo);
        }
        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(nudLegajo.Text)) return false;

            if (string.IsNullOrEmpty(txtApellido.Text)) return false;

            if (string.IsNullOrEmpty(txtNombre.Text)) return false;

            if (string.IsNullOrEmpty(txtDni.Text)) return false;

            if (string.IsNullOrEmpty(txtCuil.Text)) return false;

            if (nudLegajo.Value == 0) return false;

            if (string.IsNullOrEmpty(cmbTipoEmpleado.Text)) return false;

            return true;
        }
    }
}
