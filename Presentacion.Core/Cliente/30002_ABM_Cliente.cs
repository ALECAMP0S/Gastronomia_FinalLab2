using Presentacion.Base.Varios;
using Servicio.Core.Cliente;
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

namespace Presentacion.Core.Cliente
{
    public partial class _30002_ABM_Cliente : FormularioABM
    {
        private readonly IClienteServicio _clienteServicio;


        public _30002_ABM_Cliente()
        {
            InitializeComponent();
        }
        public _30002_ABM_Cliente(string _tipoOperacion, long? _entidadId = default(long?))
            : base(_tipoOperacion, _entidadId)
        {

            InitializeComponent();
            _clienteServicio = new ClienteServicio();

            nudCodigo.Enter += txt_Enter;
            nudCodigo.Leave += txt_Leave;

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
            nudCodigo.Value = _clienteServicio.ObtenerSiguienteCodigo();
        }
        public override void CargarDatos(long? entidadId)
        {
            try
            {
                var cliente = _clienteServicio.ObtenerPorId(entidadId.Value);

                txtApellido.Text = cliente.Apellido;
                txtDireccion.Text = cliente.Direccion;
                txtDni.Text = cliente.Dni;
                txtNombre.Text = cliente.Nombre;
                txtTelefono.Text = cliente.Telefono;
                nudCodigo.Value = cliente.Codigo;
                txtCuil.Text = cliente.Cuil;
                txtCelular.Text = cliente.Celular;
                chkActivarCtaCte.Checked = cliente.TieneCtaCte;
                nudMontoMaximoCtaCte.Value = cliente.MontoMaximoCtaCte;


                nudCodigo.Focus();
            }
            catch (ArgumentNullException exNull)
            {
                Mensaje.Mostrar("Hubo un error", Mensaje.Tipo.Informacion);
                nudCodigo.Focus();
            }
        }
        public override bool EjecutarComandoNuevo()
        {
            try
            {
                _clienteServicio.Insertar(new ClienteDto
                {
                    Nombre = txtNombre.Text,
                    Codigo = (int)nudCodigo.Value,
                    Dni = txtDni.Text,
                    Apellido = txtApellido.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Celular = txtCelular.Text,
                    Cuil = txtCuil.Text,
                    TieneCtaCte = chkActivarCtaCte.Checked ? true : false,
                    MontoMaximoCtaCte = nudMontoMaximoCtaCte.Value


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
                if (!VerificarSiExiste(entidadId.Value, (int)nudCodigo.Value))
                {
                    _clienteServicio.Modificar(new ClienteDto
                    {
                        Id = entidadId.Value,
                        Nombre = txtNombre.Text,
                        Codigo = (int)nudCodigo.Value,
                        Dni = txtDni.Text,
                        Apellido = txtApellido.Text,
                        Direccion = txtDireccion.Text,
                        Telefono = txtTelefono.Text,
                        Celular = txtCelular.Text,
                        Cuil = txtCuil.Text,
                        TieneCtaCte = chkActivarCtaCte.Checked ? true : false,
                        MontoMaximoCtaCte = nudMontoMaximoCtaCte.Value
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
                _clienteServicio.Eliminar(new ClienteDto
                {
                    Id = entidadId.Value,
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
        private bool VerificarSiExiste(long? clienteId, int Codigo)
        {
            return _clienteServicio.VerificarSiExiste(clienteId, Codigo);
        }
        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(nudCodigo.Text)) return false;

            if (string.IsNullOrEmpty(txtApellido.Text)) return false;

            if (string.IsNullOrEmpty(txtNombre.Text)) return false;

            if (string.IsNullOrEmpty(txtDni.Text)) return false;

            if (string.IsNullOrEmpty(txtCuil.Text)) return false;

            if (nudCodigo.Value == 0) return false;


            return true;
        }
    }
}
