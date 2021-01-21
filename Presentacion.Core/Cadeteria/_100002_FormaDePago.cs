using Presentacion.Base;
using Presentacion.Base.Varios;
using Presentacion.Core.Facturacion;
using Servicio.Core.Cliente;
using Servicio.Core.ComprobanteDelivery;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Cadeteria
{
    public partial class _100002_FormaDePago : FormularioBase
    {
        private long _clienteId;
        private ComprobanteDeliveryDto _comprobante;
        private readonly IComprobanteDelivery _comprobanteDelivery;
        private readonly IClienteServicio _clienteServicio;
        public _100002_FormaDePago(long clienteId)
            : this(new ComprobanteDelivery(), new ClienteServicio())
        {
            _clienteId = clienteId;
            InitializeComponent();
        }
        public _100002_FormaDePago(IComprobanteDelivery comprobanteDelivery, IClienteServicio clienteServicio)
        {
            _comprobanteDelivery = comprobanteDelivery;
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

        private void _100002_FormaDePago_Load(object sender, EventArgs e)
        {
            var cliente =_clienteServicio.ObtenerPorId(_clienteId);
            var comprobante = _comprobanteDelivery.ObtenerComprobantePorCliente(_clienteId);
            txtCliente.Text = cliente.Apellido + " " + cliente.Nombre;
            txtTotal.Text = comprobante.Total.ToString();

            if (string.IsNullOrEmpty(txtCliente.Text))
            {
                Mensaje.Mostrar("No se eligio a un cliente", Mensaje.Tipo.Stop);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _comprobanteDelivery.QuitarComprobante(_clienteId);
            Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (chkCtaCte.Checked)
            {
                Mensaje.Mostrar("Se realizo el pago con cuenta corriente", Mensaje.Tipo.Informacion);
                Close();
                var comprobanteLookUp = new ComprobanteDeliveryLookUp(_clienteId);
                comprobanteLookUp.ShowDialog();
                _comprobanteDelivery.ComprobanteCtaCte(_clienteId);

            }
            else
            {
                Mensaje.Mostrar("Se realizo el pago como consumidor final", Mensaje.Tipo.Informacion);
                Close();
                var comprobanteLookUp = new ComprobanteDeliveryLookUp(_clienteId);
                comprobanteLookUp.ShowDialog();
                _comprobanteDelivery.QuitarComprobante(_clienteId);

            }
        }
    }
}
