using Presentacion.Base;
using Presentacion.Base.Varios;
using Presentacion.Core.Cliente;
using Presentacion.Core.Facturacion;
using Servicio.Core.Cliente;
using Servicio.Core.ComprobanteSalon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Venta_en_Salon
{
    public partial class _10003_FormaDePago : FormularioBase
    {
        public bool realizoOperacion;
        private long _clienteId;
        private long _mesaId;
        private ComprobanteSalonDto _comprobante;
        private readonly IComprobanteSalon _comprobanteSalon;
        private readonly IClienteServicio _clienteServicio;
        public _10003_FormaDePago(long mesaId)
            : this(new ComprobanteSalon(), new ClienteServicio())
        {
            InitializeComponent();
            realizoOperacion = false;
            _mesaId = mesaId;
        }
        public _10003_FormaDePago(IComprobanteSalon comprobanteSalon, IClienteServicio clienteServicio)
        {
            _comprobanteSalon = comprobanteSalon;
            _clienteServicio = clienteServicio;
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

        private void btnCliente_Click(object sender, EventArgs e)
        {
            var lookUpProducto = new Cliente_LookUp();
            lookUpProducto.ShowDialog();
            if (lookUpProducto.Entidad != null)
            {
                var EmpleadoSeleccionado = (ClienteDto)lookUpProducto.Entidad;
                _clienteId = EmpleadoSeleccionado.Id;
                 var comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_mesaId);
                _comprobanteSalon.AgregarCliente(_mesaId, _clienteId);
                txtCliente.Text = EmpleadoSeleccionado.Apellido + " " + EmpleadoSeleccionado.Nombre;
                txtTotal.Text = comprobante.Total.ToString();

                if (EmpleadoSeleccionado.TieneCtaCte == true)
                {
                    chkCtaCte.Enabled = true;
                }
                else
                {
                    chkCtaCte.Enabled = false;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_mesaId);
            if (comprobante.Total == 0)
            {
                Close();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Seguro que quiere eliminar el comprobante?", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _comprobanteSalon.QuitarComprobante(_mesaId);
                    Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    realizoOperacion = true;
                    Close();
                }
            }

        }
        // ya vengo
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (chkCtaCte.Checked)
            {
                Mensaje.Mostrar("Se realizo el pago con cuenta corriente", Mensaje.Tipo.Informacion);
                Close();
                var comprobanteLookUp = new Comprobante_LookUp(_mesaId);
                comprobanteLookUp.ShowDialog();
                _comprobanteSalon.ComprobanteCtaCte(_mesaId);

            }
            else
            {
                Mensaje.Mostrar("Se realizo el pago como consumidor final", Mensaje.Tipo.Informacion);
                Close();
                var comprobanteLookUp = new Comprobante_LookUp(_mesaId);
                comprobanteLookUp.ShowDialog();
                _comprobanteSalon.QuitarComprobante(_mesaId);

            }
        }
    }
}
