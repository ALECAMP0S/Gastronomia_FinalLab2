using DAL;
using Presentacion.Base;
using Presentacion.Base.Varios;
using Presentacion.Core.Venta_en_Salon;
using Servicio.Core.ComprobanteSalon;
using Servicio.Core.Empleado;
using Servicio.Core.ListaPprecio;
using Servicio.Core.ListaPrecioProducto;
using Servicio.Core.Mesa;
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

namespace Presentacion.Core.ControlesUsuarios
{
    public partial class CombinarMesas : FormularioBase
    {
        public long _mesa1Id;
        public long _mesa2Id;
        private IComprobanteSalon _comprobanteSalon;
        private IListaPrecioProducto _listaPrecioProducto;
        private IProductoServicio _productoServicio;
        private IMesaServicio _mesaServicio;
        private IEmpleadoServicio _empladoServicio;
        public bool realizoOperacion;

        public CombinarMesas()
           : this(new MesaServicio(), new ComprobanteSalon(), new EmpleadoServicio(), new ListaPrecioProductos(), new ProductoServicio())

        {
            realizoOperacion = false;
            InitializeComponent();
        }
        public CombinarMesas(IMesaServicio mesaServicio, IComprobanteSalon comprobanteSalon, IEmpleadoServicio empleadoServicio,
            IListaPrecioProducto listaPrecioServicio, IProductoServicio productoServicio)
        {
            _comprobanteSalon = comprobanteSalon;
            _listaPrecioProducto = listaPrecioServicio;
            _productoServicio = productoServicio;
            _mesaServicio = mesaServicio;
            _empladoServicio = empleadoServicio;
        }
        public void PoblarCombos()
        {
            var mesas = _mesaServicio.ObtenerMesasOcupadas();

            PoblarComboBox(cmbMesa2, mesas, "Descripcion", "Numero");

            var mesas2 = _mesaServicio.ObtenerMesasOcupadas();


            PoblarComboBox(cmbMesa1, mesas2, "Descripcion", "Numero");

        }
        public void JuntarMesas(long primeraMesa, long segundaMesa)
        {
            var mesa1 = _comprobanteSalon.ObtenerComprobantePorMesa(primeraMesa);
            var mesa2 = _comprobanteSalon.ObtenerComprobantePorMesa(segundaMesa);
            

            foreach (var detalle in mesa1.ComprobanteSalonDetalleDtos)
            {
                var dto = _productoServicio.ObtenerPorId(detalle.ProductoId);

                var id = _listaPrecioProducto.ObtenerListaPorProductoId(dto.Id);

                var producto = _listaPrecioProducto.ObtnerProducto(dto.Codigo.ToString(), id.ListaPrecioId);

                _comprobanteSalon.AgregarItem(mesa2.Id,detalle.Cantidad, producto, id.ListaPrecioId);
               // _comprobanteSalon.SeleccionarMozo(mesa1.Id, empleadoMozo);
            }
            foreach (var detalle in mesa1.ComprobanteSalonDetalleDtos)
            {
                var dto = _productoServicio.ObtenerPorId(detalle.ProductoId);
                var id = _listaPrecioProducto.ObtenerListaPorProductoId(dto.Id);
                var producto = _listaPrecioProducto.ObtnerProducto(dto.Codigo.ToString(), id.ListaPrecioId);
                _comprobanteSalon.DisminuirCantidadItem(mesa1.Id, producto, detalle.Cantidad);
            }

            _comprobanteSalon.QuitarComprobante(primeraMesa);
            _mesaServicio.CambiarEstado(_mesa2Id, EstadoMesa.Combinada);
            _mesaServicio.CambiarEstado(_mesa1Id, EstadoMesa.Libre);
            MessageBox.Show(@"Se combino la mesa con exito", @"Advertencia", MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);
            this.Close();

        }

        private void btnCombinar_Click(object sender, EventArgs e)
        {
            _mesa1Id = ((MesaDto)cmbMesa1.SelectedItem).Id;
            _mesa2Id = ((MesaDto)cmbMesa2.SelectedItem).Id;

            if (_mesa1Id != _mesa2Id)
            {
                JuntarMesas(_mesa1Id, _mesa2Id);
                realizoOperacion = true;
            }

            else
            {
                Mensaje.Mostrar("Elija mesas diferentes", Mensaje.Tipo.Informacion);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CombinarMesas_Load(object sender, EventArgs e)
        {
            PoblarCombos();
        }
    }
}
