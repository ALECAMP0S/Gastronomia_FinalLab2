using Presentacion.Base;
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

namespace Presentacion.Core.Facturacion
{
    public partial class ComprobanteDeliveryLookUp : FormularioBase
    {
        private readonly IComprobanteDelivery _comprobanteDelivery;
        private long _clienteId;
        private ComprobanteDeliveryDto _comprobante;
        public ComprobanteDeliveryLookUp(long clienteId)
            : this(new ComprobanteDelivery())
        {
            _clienteId = clienteId;
            InitializeComponent();
        }
        public ComprobanteDeliveryLookUp(IComprobanteDelivery comprobanteDelivery)
        {
            _comprobanteDelivery = comprobanteDelivery;
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
        public void ActualizarDatos(string cadenaBuscar)
        {
            _comprobante = _comprobanteDelivery.ObtenerComprobantePorCliente(_clienteId);
            nudTOTAL.Value = _comprobante.ComprobanteDeliveryDetalleDtos.Sum(x => x.SubTotal);
            dgvGrilla.DataSource = _comprobante.ComprobanteDeliveryDetalleDtos.ToList();
            FormatearGrilla(dgvGrilla);
        }

        private void ComprobanteDeliveryLookUp_Load(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);

        }
    }
}
