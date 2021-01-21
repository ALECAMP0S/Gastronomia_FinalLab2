using Presentacion.Base.Varios;
using Servicio.Core.Proveedor;
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

namespace Presentacion.Core.Proveedor
{
    public partial class _40002_ABM_Proveedor : FormularioABM
    {
        private readonly IProveedorServicio _proveedorServicio;

        
        public _40002_ABM_Proveedor(string _tipoOperacion, long? _entidadId = default(long?))
            : base(_tipoOperacion, _entidadId)
        {

            InitializeComponent();
            _proveedorServicio = new ProveedorServicio();
            txtNombreFantasia.Enter += txt_Enter;
            txtNombreFantasia.Leave += txt_Leave;
            txtNombreFantasia.KeyPress += Validacion.NoSimbolos;
            txtNombreFantasia.KeyPress += Validacion.NoInyeccion;
            txtNombreFantasia.KeyPress += Validacion.NoNumeros;

            txtRazonSocial.Enter += txt_Enter;
            txtRazonSocial.Leave += txt_Leave;
            txtRazonSocial.KeyPress += Validacion.NoSimbolos;
            txtRazonSocial.KeyPress += Validacion.NoInyeccion;
            txtRazonSocial.KeyPress += Validacion.NoNumeros;

            txtTelefono.Enter += txt_Enter;
            txtTelefono.Leave += txt_Leave;
            txtTelefono.KeyPress += Validacion.NoSimbolos;
            txtTelefono.KeyPress += Validacion.NoInyeccion;
            txtTelefono.KeyPress += Validacion.NoLetras;


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
        public override void CargarDatos(long? entidadId)
        {
            try
            {
                var proveedor = _proveedorServicio.ObtenerPorId(entidadId.Value);

                txtDireccion.Text = proveedor.Direccion;
                txtTelefono.Text = proveedor.Telefono;
                txtCuil.Text = proveedor.Cuil;
                cmbCondicionIva.SelectedIndex = (int)proveedor.CondicionIva;
                txtNombreFantasia.Text = proveedor.NombreFantacia;
                txtRazonSocial.Text = proveedor.RazonSocial;
                dtpFechaInicio.Value = proveedor.FechaIncioActividad;
                nudIngresosBrutos.Value = Convert.ToDecimal(proveedor.IngresosBrutos);

            }
            catch (ArgumentNullException exNull)
            {
                Mensaje.Mostrar("Hubo un error", Mensaje.Tipo.Informacion);
            }

        }
        public override bool EjecutarComandoNuevo()
        {
            try
            {

                _proveedorServicio.Insertar(new ProveedorDto
                {
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Cuil = txtCuil.Text,
                    CondicionIva = cmbCondicionIva.SelectedIndex + 1,
                    NombreFantacia = txtNombreFantasia.Text,
                    FechaIncioActividad = dtpFechaInicio.Value,
                    IngresosBrutos =nudIngresosBrutos.Value.ToString(),
                    RazonSocial = txtRazonSocial.Text
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
                if (VerificarSiExiste(entidadId.Value))
                {



                    _proveedorServicio.Modificar(new ProveedorDto
                    {
                        Id = entidadId.Value,
                        Direccion = txtDireccion.Text,
                        Telefono = txtTelefono.Text,
                        Cuil = txtCuil.Text,
                        CondicionIva = cmbCondicionIva.SelectedIndex + 1,
                        RazonSocial = txtRazonSocial.Text,
                        NombreFantacia = txtNombreFantasia.Text,
                        FechaIncioActividad = dtpFechaInicio.Value,
                        IngresosBrutos = Convert.ToString(nudIngresosBrutos.Value)

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
                _proveedorServicio.Eliminar(new ProveedorDto
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
        private bool VerificarSiExiste(long Id)
        {
            return _proveedorServicio.VerificarSiExiste(Id);

        }
        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(dtpFechaInicio.Text))
            {
                Mensaje.Mostrar("La fecha es Obligatoria", Mensaje.Tipo.Informacion);
                dtpFechaInicio.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtNombreFantasia.Text))
            {
                Mensaje.Mostrar("Nombre Fantasia es Obligatoria", Mensaje.Tipo.Informacion);
                txtNombreFantasia.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtRazonSocial.Text))
            {
                Mensaje.Mostrar("La razon social es Obligatoria", Mensaje.Tipo.Informacion);
                txtNombreFantasia.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                Mensaje.Mostrar("La direccion es Obligatoria", Mensaje.Tipo.Informacion);
                txtNombreFantasia.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtCuil.Text))
            {
                Mensaje.Mostrar("El cuil es Obligatoria", Mensaje.Tipo.Informacion);
                txtNombreFantasia.Focus();
                return false;
            }

            if (nudIngresosBrutos.Value == 0)
            {
                Mensaje.Mostrar("Ingresos brutos es Obligatorio", Mensaje.Tipo.Informacion);
                txtNombreFantasia.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cmbCondicionIva.Text))
            {
                Mensaje.Mostrar("Condicion iva es Obligatoria", Mensaje.Tipo.Informacion);
                txtNombreFantasia.Focus();
                return false;
            }

            return true;
        }
    }
}
