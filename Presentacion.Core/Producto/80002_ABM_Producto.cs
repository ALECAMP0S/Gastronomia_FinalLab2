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
using Servicio.Core.SubRubro;
using Servicio.Core.Marca;
using Servicio.Core.Producto;
using Presentacion.Base.Varios;

namespace Presentacion.Core.Producto
{
    public partial class _80002_ABM_Producto : FormularioABM
    {
        private readonly ISubRubroServicio _subRubroServicio;
        private readonly IMarcaServicio _marcaServicio;
        private readonly IProductoServicio _productoServicio;
        public _80002_ABM_Producto()
        {
            InitializeComponent();
        }
        public _80002_ABM_Producto(string _tipoOperacion, long? _entidadId = default(long?))
            : base(_tipoOperacion, _entidadId)
        {

            InitializeComponent();
            _productoServicio = new ProductoServicio();
            _subRubroServicio = new SubRubroServicio();
            _marcaServicio = new MarcaServicio();
            nudCodigo.Enter += txt_Enter;
            nudCodigo.Leave += txt_Leave;

            nudCodigo.Enter += txt_Enter;
            nudCodigo.Leave += txt_Leave;

            txtDescripcion.Enter += txt_Enter;
            txtDescripcion.Leave += txt_Leave;
            txtDescripcion.KeyPress += Validacion.NoSimbolos;
            txtDescripcion.KeyPress += Validacion.NoInyeccion;


            cmbMarca.Enter += txt_Enter;
            cmbMarca.Leave += txt_Leave;
            cmbMarca.KeyPress += Validacion.NoSimbolos;
            cmbMarca.KeyPress += Validacion.NoInyeccion;

            cmbSubRubro.Enter += txt_Enter;
            cmbSubRubro.Leave += txt_Leave;
            cmbSubRubro.KeyPress += Validacion.NoSimbolos;
            cmbSubRubro.KeyPress += Validacion.NoInyeccion;

            Init(_tipoOperacion, entidadId);
        }
        public override void LimpiarDatos(object obj)
        {
            base.LimpiarDatos(obj);
            ObtenerSiguienteCodigo();
        }
        private void ObtenerSiguienteCodigo()
        {
            nudCodigo.Value =_productoServicio.ObtenerSiguienteLegajo();
        }
        public override void CargarDatos(long? entidadId)
        {
            try
            {
                var producto = _productoServicio.ObtenerPorId(entidadId.Value);

                txtDescripcion.Text = producto.Descripcion;
                nudCodigo.Value = Convert.ToDecimal(producto.Codigo);
                nudCodigoBarra.Value = Convert.ToDecimal(producto.CodigoBarra);
                cmbSubRubro.SelectedIndex = (int)producto.SubRubroId;
                nudStock.Value = producto.Stock;
                cmbMarca.SelectedIndex = (int)producto.MarcaId;

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
                _productoServicio.Insertar(new ProductoDto
                {
                    Descripcion = txtDescripcion.Text,
                    Codigo = (int)nudCodigo.Value,
                    CodigoBarra = nudCodigoBarra.Value.ToString(),
                    Stock = nudStock.Value,
                    SubRubroId = cmbSubRubro.SelectedIndex + 1,
                    MarcaId = cmbMarca.SelectedIndex + 1

                });

                Mensaje.Mostrar("Los datos se grabaron Correctamente.", Mensaje.Tipo.Informacion);
                return true;
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(ex, Mensaje.Tipo.Error);
            }
            return false;
        }
        public override bool EjecutarComandoModificar()
        {
            try
            {
                if (!VerificarSiExiste(entidadId, (int)nudCodigo.Value))
                {
                    _productoServicio.Modificar(new ProductoDto
                    {
                        Id = (int)entidadId.Value,
                        Descripcion = txtDescripcion.Text,
                        Codigo = (int)nudCodigo.Value,
                        CodigoBarra = nudCodigoBarra.Value.ToString(),
                        Stock = nudStock.Value,
                        SubRubroId = cmbSubRubro.SelectedIndex + 1,
                        MarcaId = cmbMarca.SelectedIndex + 1
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
                    _productoServicio.Eliminar(new ProductoDto
                    {
                        Id = (int)entidadId.Value,

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
        private bool VerificarSiExiste(long? productoId, int legajo)
        {
            return _productoServicio.VerificarSiExiste(productoId, legajo);
        }
        public override bool VerificarDatosObligatorios()
        {
            if (nudCodigo.Value == 0) return false;
            if (string.IsNullOrEmpty(nudCodigo.Text)) return false;

            if (string.IsNullOrEmpty(txtDescripcion.Text)) return false;

            if (nudCodigoBarra.Value == 0) return false;

            if (string.IsNullOrEmpty(nudStock.Text)) return false;

            if (string.IsNullOrEmpty(cmbMarca.Text)) return false;

            if (nudCodigo.Value == 0) return false;

            if (string.IsNullOrEmpty(cmbSubRubro.Text)) return false;

            return true;
        }

        private void CargarComboSubRubro()
        {
            PoblarComboBox(cmbMarca, _marcaServicio.ObtenerTodo(), "Descripcion", "Codigo");
        }

        private void CargarComboMarca()
        {
            PoblarComboBox(cmbSubRubro, _subRubroServicio.ObtenerTodo(), "Descripcion", "Codigo");
        }

        private void _80002_ABM_Producto_Load(object sender, EventArgs e)
        {
            CargarComboMarca();
            CargarComboSubRubro();
        }
    }
}
