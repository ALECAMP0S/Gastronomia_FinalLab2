using System;
using System.Linq;
using System.Windows.Forms;
using DAL;
using Presentacion.Base;
using Presentacion.Core.Producto;
using Servicio.Core.ComprobanteSalon;
using Servicio.Core.ListaPprecio;
using Servicio.Core.Producto;
using Presentacion.Core.Mozo;
using Servicio.Core.Empleado;

namespace Presentacion.Core.Venta_en_Salon
{
    public partial class _10002_Venta : FormularioBase
    {
        private long _mesaId;
        private ComprobanteSalonDto _comprobante;
        private readonly IComprobanteSalon _comprobanteSalon;
        private readonly IListaPrecioServicio _listaPrecioServicio;
        private readonly IProductoServicio _productoServicio;
        private readonly IEmpleadoServicio _empleadoServicio;

        public _10002_Venta(long mesaId)
            : this(new ComprobanteSalon(), new ListaPrecioServicio(), new EmpleadoServicio(), new ProductoServicio())
        {
            InitializeComponent();

            
            _mesaId = mesaId;
        }

        public _10002_Venta(IComprobanteSalon comprobanteSalon, IListaPrecioServicio listaPrecioServicio,IEmpleadoServicio empleadoServicio
            ,IProductoServicio productoServicio)
        {
            _comprobanteSalon = comprobanteSalon;
            _listaPrecioServicio = listaPrecioServicio;
            _empleadoServicio = empleadoServicio;
            _productoServicio = productoServicio;
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

        private void _10002_Venta_Load(object sender, System.EventArgs e)
        {
            CargarDatos();
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

        private void CargarDatos()
        {
            PoblarComboBox(cmbListaPrecio, _listaPrecioServicio.Obtener(), "Descripcion", "Id");

            txtFecha.Text = DateTime.Now.ToString();
            _comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_mesaId);
            lblEmpleado.Text = _comprobante.Mozo;
            nudTOTAL.Value = _comprobante.ComprobanteSalonDetalleDtos.Sum(x=>x.SubTotal);

            dgvGrilla.DataSource = _comprobante.ComprobanteSalonDetalleDtos.ToList();

            FormatearGrilla(dgvGrilla);
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {


            if ((char) Keys.Enter != e.KeyChar) return;

            var listaId = (long) cmbListaPrecio.SelectedValue;

            var producto = _productoServicio.ObtenerPorDescripcion(txtDescripcion.Text,listaId);
            if (string.IsNullOrEmpty(txtDescripcion.Text)) return;

            if (producto != null)
            {
                nudCantidad.Enabled = true;


                _comprobanteSalon.AgregarItem(_comprobante.Id, (int)nudCantidad.Value, producto,listaId);
                _comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_mesaId);

                dgvGrilla.DataSource = _comprobante.ComprobanteSalonDetalleDtos.ToList();
                nudTOTAL.Value = _comprobante.ComprobanteSalonDetalleDtos.Sum(x => x.SubTotal);
            }
            else
            {
                var lookUpProducto = new Producto_LookUp(listaId);
                lookUpProducto.ShowDialog();
                if (lookUpProducto.Entidad != null)
                {
                    var productoSeleccionado = (ProductoDto) lookUpProducto.Entidad;
                    txtDescripcion.Text = productoSeleccionado.Codigo.ToString();
                    nudPrecio.Value = productoSeleccionado.PrecioPublico;

                    _comprobanteSalon.AgregarItem(_comprobante.Id,1, productoSeleccionado,listaId);
                    _comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_mesaId);

                    dgvGrilla.DataSource = _comprobante.ComprobanteSalonDetalleDtos.ToList();
                    nudTOTAL.Value = _comprobante.ComprobanteSalonDetalleDtos.Sum(x => x.SubTotal);
                    nudCantidad.Enabled = true;


                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var listaId = (long)cmbListaPrecio.SelectedValue;
            var producto = _productoServicio.ObtenerPorDescripcion(txtDescripcion.Text, listaId);

            _comprobanteSalon.AgregarItem(_comprobante.Id, (int)nudCantidad.Value, producto, listaId);
            _comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_mesaId);

            dgvGrilla.DataSource = _comprobante.ComprobanteSalonDetalleDtos.ToList();
            nudTOTAL.Value = _comprobante.ComprobanteSalonDetalleDtos.Sum(x => x.SubTotal);
        }

        private void txtCodigoEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoEmpleado.Text)) return;


            if ((char)Keys.Enter != e.KeyChar) return;


            var mozo = BuscarMozo(txtCodigoEmpleado.Text);

            if (mozo != null)
            {
                var empleadoSeleccionado = _empleadoServicio.ObtenerPorLegajo(txtCodigoEmpleado.Text);
                    txtCodigoEmpleado.Text = empleadoSeleccionado.Legajo.ToString();
                    lblEmpleado.Text = empleadoSeleccionado.Apellido + " " + empleadoSeleccionado.Nombre;
            }
            else
            {
                var lookUpProducto = new Mozo_LookUp();
                lookUpProducto.ShowDialog();
                if (lookUpProducto.Entidad != null)
                {
                    var empleadoSeleccionado = (EmpleadoDto)lookUpProducto.Entidad;
                    txtCodigoEmpleado.Text = empleadoSeleccionado.Legajo.ToString();
                    lblEmpleado.Text = empleadoSeleccionado.Apellido + " " + empleadoSeleccionado.Nombre;
                    
                }
            }
        }

        private object BuscarMozo(string text)
        {
            return _empleadoServicio.ObtenerPorLegajo(text);
        }

        private void btnLookUpEmpleado_Click(object sender, EventArgs e)
        {
            var lookUpProducto = new Mozo_LookUp();
            lookUpProducto.ShowDialog();
            if (lookUpProducto.Entidad != null)
            {
                var empleadoSeleccionado = (EmpleadoDto)lookUpProducto.Entidad;
                txtCodigoEmpleado.Text = empleadoSeleccionado.Legajo.ToString();
                lblEmpleado.Text = empleadoSeleccionado.Apellido + " " + empleadoSeleccionado.Nombre;

            }
        }

        private void btnCambiarCantidadItem_Click(object sender, EventArgs e)
        {

            var listaId = (long)cmbListaPrecio.SelectedValue;
            var producto = _productoServicio.ObtenerPorDescripcion(txtDescripcion.Text, listaId);

            var productoSeleccionado =_productoServicio.ObtenerPorId(producto.Id);
            _comprobanteSalon.EliminarItem(_comprobante.Id, 1, productoSeleccionado,listaId);
            _comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_mesaId);

            dgvGrilla.DataSource = _comprobante.ComprobanteSalonDetalleDtos.ToList();
            nudTOTAL.Value = _comprobante.ComprobanteSalonDetalleDtos.Sum(x => x.SubTotal);
        }

        private void dgvGrilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvGrilla_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtDescripcion.Text = dgvGrilla.CurrentRow.Cells[6].Value.ToString();

        }
    }
}
