using Presentacion.Base;
using Presentacion.Core.Producto;
using Servicio.Core.ComprobanteDelivery;
using Servicio.Core.ComprobanteDelivery;
using Servicio.Core.Empleado;
using Servicio.Core.ListaPprecio;
using Servicio.Core.Producto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicio.Core.Empleado;
using Presentacion.Core.Cliente;
using Servicio.Core.Cliente;
using Presentacion.Core.Facturacion;
using Presentacion.Base.Varios;

namespace Presentacion.Core.Cadeteria
{
    public partial class _100001_Cadeteria : FormularioBase
    {
        private long _clienteId;
        private ComprobanteDeliveryDto _comprobante;
        private readonly IComprobanteDelivery _comprobanteDelivery;
        private readonly IListaPrecioServicio _listaPrecioServicio;
        private readonly IProductoServicio _productoServicio;
        private readonly IEmpleadoServicio _EmpleadoServicio;

        public _100001_Cadeteria()
            : this(new ComprobanteDelivery(), new ListaPrecioServicio(), new EmpleadoServicio(), new ProductoServicio())
        {
            InitializeComponent();
        }
        public _100001_Cadeteria(IComprobanteDelivery comprobanteDelivery, IListaPrecioServicio listaPrecioServicio, IEmpleadoServicio EmpleadoServicio
            , IProductoServicio productoServicio)
        {
            _comprobanteDelivery = comprobanteDelivery;
            _listaPrecioServicio = listaPrecioServicio;
            _EmpleadoServicio = EmpleadoServicio;
            _productoServicio = productoServicio;
        }
        public override void FormatearGrilla(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);

            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Descripcion"].HeaderText = @"Descripción";

            dgvGrilla.Columns["Precio"].Visible = true;
            dgvGrilla.Columns["Precio"].Width = 100;
            dgvGrilla.Columns["Precio"].HeaderText = @"Precio";

            dgvGrilla.Columns["Cantidad"].Visible = true;
            dgvGrilla.Columns["Cantidad"].Width = 50;
            dgvGrilla.Columns["Cantidad"].HeaderText = @"Cantidad";

            dgvGrilla.Columns["SubTotal"].Visible = true;
            dgvGrilla.Columns["SubTotal"].Width = 100;
            dgvGrilla.Columns["SubTotal"].HeaderText = @"SubTotal";

            dgvGrilla.Columns["Codigo"].Visible = true;
            dgvGrilla.Columns["Codigo"].Width = 100;
            dgvGrilla.Columns["Codigo"].HeaderText = @"Código";

            dgvGrilla.Columns["CodigoBarra"].Visible = true;
            dgvGrilla.Columns["CodigoBarra"].Width = 100;
            dgvGrilla.Columns["CodigoBarra"].HeaderText = @"Código Barra";

        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void _100001_Cadeteria_Load(object sender, EventArgs e)
        {
            CargarDatos();

        }

        private void CargarDatos()
        {
            PoblarComboBox(cmbListaPrecio, _listaPrecioServicio.Obtener(), "Descripcion", "Id");

            txtFecha.Text = DateTime.Now.ToString();
            if (_clienteId != 0 )
            {
                _comprobante = _comprobanteDelivery.ObtenerComprobantePorCliente(_clienteId);
                lblEmpleado.Text = _comprobante.Cadete;
                nudTOTAL.Value = _comprobante.ComprobanteDeliveryDetalleDtos.Sum(x => x.SubTotal);
                dgvGrilla.DataSource = _comprobante.ComprobanteDeliveryDetalleDtos.ToList();

                FormatearGrilla(dgvGrilla);
            }
        }


        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Enter != e.KeyChar) return;

            var listaId = (long)cmbListaPrecio.SelectedValue;

            var producto = _productoServicio.ObtenerPorDescripcion(txtDescripcion.Text, listaId);
            if (string.IsNullOrEmpty(txtDescripcion.Text)) return;

            if (producto != null)
            {
                if (_clienteId != 0)
                {

                    if (!string.IsNullOrEmpty(txtCodigoCadete.Text))
                    {

                        if (_comprobante != null)
                        {
                            nudCantidad.Enabled = true;
                            _comprobanteDelivery.AgregarItem(_comprobante.Id, (int)nudCantidad.Value, producto, listaId);
                            _comprobante = _comprobanteDelivery.ObtenerComprobantePorCliente(_clienteId);

                            dgvGrilla.DataSource = _comprobante.ComprobanteDeliveryDetalleDtos.ToList();
                            nudTOTAL.Value = _comprobante.ComprobanteDeliveryDetalleDtos.Sum(x => x.SubTotal);
                        }
                    }
                    else
                    {
                        Mensaje.Mostrar(" Elija un empleado", Mensaje.Tipo.Informacion);
                    }
                }
                else
                {
                    Mensaje.Mostrar(" Elija un cliente", Mensaje.Tipo.Informacion);
                }
            }
            else
            {
                var lookUpProducto = new Producto_LookUp(listaId);
                lookUpProducto.ShowDialog();
                if (lookUpProducto.Entidad != null)
                {
                    if (_clienteId != 0)
                    {
                        if (!string.IsNullOrEmpty(txtCodigoCadete.Text))
                        {


                            var productoSeleccionado = (ProductoDto)lookUpProducto.Entidad;
                            txtDescripcion.Text = productoSeleccionado.Codigo.ToString();
                            nudPrecio.Value = productoSeleccionado.PrecioPublico;
                            //comprobante null
                            if (_comprobante != null)
                            {
                                _comprobanteDelivery.AgregarItem(_comprobante.Id, 1, productoSeleccionado, listaId);
                                _comprobante = _comprobanteDelivery.ObtenerComprobantePorCliente(_clienteId);

                                dgvGrilla.DataSource = _comprobante.ComprobanteDeliveryDetalleDtos.ToList();
                                nudTOTAL.Value = _comprobante.ComprobanteDeliveryDetalleDtos.Sum(x => x.SubTotal);
                                nudCantidad.Enabled = true;
                            }
                        }
                        else
                        {
                            Mensaje.Mostrar(" Elija un empleado", Mensaje.Tipo.Informacion);

                        }

                    }
                    else
                    {
                        Mensaje.Mostrar(" Elija un cliente", Mensaje.Tipo.Informacion);
                    }
                }
            }
        }

        private void txtCodigoCadete_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoCadete.Text)) return;


            if ((char)Keys.Enter != e.KeyChar) return;


            var Cadete = BuscarCadete(txtCodigoCadete.Text);

            if (Cadete != null)
            {
                var EmpleadoSeleccionado = _EmpleadoServicio.ObtenerPorLegajo(txtCodigoCadete.Text);
                txtCodigoCadete.Text = EmpleadoSeleccionado.Legajo.ToString();
                lblEmpleado.Text = EmpleadoSeleccionado.Apellido + " " + EmpleadoSeleccionado.Nombre;
            }
            else
            {
                var lookUpProducto = new Cadete_LookUp();// despues
                lookUpProducto.ShowDialog();
                if (lookUpProducto.Entidad != null)
                {
                    var EmpleadoSeleccionado = (EmpleadoDto)lookUpProducto.Entidad;
                    txtCodigoCadete.Text = EmpleadoSeleccionado.Id.ToString();
                    lblEmpleado.Text = EmpleadoSeleccionado.Apellido + " " + EmpleadoSeleccionado.Nombre;

                    
                }
            }
        }
        private object BuscarCadete(string text)
        {
            return _EmpleadoServicio.ObtenerPorLegajo(text);
        }

        private void btnLookUpEmpleado_Click_1(object sender, EventArgs e)
        {
            var lookUpProducto = new Cadete_LookUp();
            lookUpProducto.ShowDialog();
            if (lookUpProducto.Entidad != null)
            {
                var legajo = 1;
                var EmpleadoSeleccionado = (EmpleadoDto)lookUpProducto.Entidad;
                txtCodigoCadete.Text = EmpleadoSeleccionado.Id.ToString();
                lblEmpleado.Text = EmpleadoSeleccionado.Apellido + " " + EmpleadoSeleccionado.Nombre;

                int.TryParse(txtCodigoCadete.Text, out legajo);
                if (!string.IsNullOrEmpty(txtCliente.Text))
                {
                    _comprobanteDelivery.Crear(_clienteId, new ComprobanteDeliveryDto
                    {
                        CadeteId = legajo,
                        ClienteId = _clienteId,
                        Total = nudTOTAL.Value,
                        Cadete = lblClientes.Text,
                        Direccion = txtDireccion.Text

                    });
                    CargarDatos();
                }
            }
        }

        private void btnCambiarCantidadItem_Click_1(object sender, EventArgs e)
        {
            var listaId = (long)cmbListaPrecio.SelectedValue;
            var producto = _productoServicio.ObtenerPorDescripcion(txtDescripcion.Text, listaId);

            var productoSeleccionado = _productoServicio.ObtenerPorId(producto.Id);
            _comprobanteDelivery.EliminarItem(_comprobante.Id, 1, productoSeleccionado, listaId);
            _comprobante = _comprobanteDelivery.ObtenerComprobantePorCliente(_clienteId);

            dgvGrilla.DataSource = _comprobante.ComprobanteDeliveryDetalleDtos.ToList();
            nudTOTAL.Value = _comprobante.ComprobanteDeliveryDetalleDtos.Sum(x => x.SubTotal);
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            var listaId = (long)cmbListaPrecio.SelectedValue;
            var producto = _productoServicio.ObtenerPorDescripcion(txtDescripcion.Text, listaId);

            if (!string.IsNullOrEmpty(txtCliente.Text))
            {
                if (!string.IsNullOrEmpty(txtCodigoCadete.Text))
                {


                    if (producto != null)
                    {
                        _comprobante = _comprobanteDelivery.ObtenerComprobantePorCliente(_clienteId);
                        if (_comprobante != null)
                        {
                            _comprobanteDelivery.AgregarItem(_comprobante.Id, (int)nudCantidad.Value, producto, listaId);

                            dgvGrilla.DataSource = _comprobante.ComprobanteDeliveryDetalleDtos.ToList();
                            nudTOTAL.Value = _comprobante.ComprobanteDeliveryDetalleDtos.Sum(x => x.SubTotal);
                        }

                    }
                }
                else
                {
                    Mensaje.Mostrar("Elija un cadete", Mensaje.Tipo.Informacion);

                }
            }
            else
            {
                Mensaje.Mostrar("Elija un cliente", Mensaje.Tipo.Informacion);
            }
           
        }

        private void dgvGrilla_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtDescripcion.Text = dgvGrilla.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnLookUpCliente_Click(object sender, EventArgs e)
        {
            var lookUpProducto = new Cliente_LookUp();
            lookUpProducto.ShowDialog();
            if (lookUpProducto.Entidad != null)
            {
                var EmpleadoSeleccionado = (ClienteDto)lookUpProducto.Entidad;
                txtCliente.Text = EmpleadoSeleccionado.Id.ToString();
                lblClientes.Text = EmpleadoSeleccionado.Apellido + " " + EmpleadoSeleccionado.Nombre;
                txtDireccion.Text = EmpleadoSeleccionado.Direccion;
                _clienteId = EmpleadoSeleccionado.Id;
                if (_comprobante == null)
                {
                    var legajo = 0;
                    int.TryParse(txtCodigoCadete.Text, out legajo);
                    if (legajo != 0)
                    {
                        _comprobanteDelivery.Crear(_clienteId, new ComprobanteDeliveryDto
                        {
                            CadeteId = legajo,
                            ClienteId = _clienteId,
                            Total = nudTOTAL.Value,
                            Cadete = lblClientes.Text,
                            Direccion = txtDireccion.Text

                    });
                        CargarDatos();
                    }
                    

                }
            }
        }

        private void txtEnviar_Click(object sender, EventArgs e)
        {
            if (_clienteId == 0)
            {
                Mensaje.Mostrar("Elija un cliente", Mensaje.Tipo.Informacion);
            }
            else
            {
                if (nudTOTAL.Value != 0)
                {
                    Close();
                    var comprobanteLookUp = new _100002_FormaDePago(_clienteId);
                    comprobanteLookUp.ShowDialog();
                }
                else
                {
                    Mensaje.Mostrar("Agregue un producto", Mensaje.Tipo.Informacion);
                }
            }
            
            
        }
    }
}

