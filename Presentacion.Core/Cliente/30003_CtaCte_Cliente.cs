using DAL;
using Presentacion.Base;
using Presentacion.Base.Varios;
using Servicio.Core.Cliente;
using Servicio.Core.ComprobanteDelivery;
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

namespace Presentacion.Core.CuentaCorriente
{
    public partial class _30003_CtaCte_Cliente : FormularioBase
    {
        public long? _clienteId;
        private readonly IClienteServicio _clienteServicio;
        private readonly IComprobanteSalon _comprobanteSalon;
        private readonly IComprobanteDelivery _comprobanteDelivery;
        private ComprobanteDeliveryDto _comprobanteDeliveryDto;
        private ComprobanteSalonDto _comprobanteSalonDto;

        public _30003_CtaCte_Cliente(long? clienteId)
            : this(new ClienteServicio(), new ComprobanteSalon(), new ComprobanteDelivery())
        {
            _clienteId = clienteId;
            InitializeComponent();
        }
        public _30003_CtaCte_Cliente(IClienteServicio clienteServicio , IComprobanteSalon comprobanteSalon, IComprobanteDelivery comprobanteDelivery)
        {
            _clienteServicio = clienteServicio;
            _comprobanteSalon = comprobanteSalon;
            _comprobanteDelivery = comprobanteDelivery;

        }
        private void _30003_CtaCte_Cliente_Load(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }
        
        public void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _clienteServicio.ObtenerClientesCtaCte(cadenaBuscar);

            FormatearGrilla(dgvGrilla);
        }
        public override void FormatearGrilla(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);

            dgvGrilla.Columns["Codigo"].Visible = true;
            dgvGrilla.Columns["Apellido"].Visible = true;
            dgvGrilla.Columns["Apellido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Nombre"].Visible = true;
            dgvGrilla.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Dni"].Visible = true;
            dgvGrilla.Columns["TieneCtaCte"].Visible = true;
            dgvGrilla.Columns["MontoMaximoCtaCte"].Visible = true;

        }
        public void FormatearGrilla2(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);

            dgvGrilla.Columns["Total"].Visible = true;
            dgvGrilla.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["MesaId"].Visible = true;
            dgvGrilla.Columns["Mozo"].Visible = true;
            dgvGrilla.Columns["Mozo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        private void btnTodas_Click(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private void btnImpagasD_Click(object sender, EventArgs e)
        {
            dgvGrilla.DataSource = _comprobanteDelivery.ObtenerComprobantesPorCliente(_clienteId);
            FormatearGrilla3(dgvGrilla);
        }

        public void FormatearGrilla3(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);

            dgvGrilla.Columns["Total"].Visible = true;
            dgvGrilla.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Cadete"].Visible = true;
            dgvGrilla.Columns["Cadete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnImpagasS_Click(object sender, EventArgs e)
        {
          
           dgvGrilla.DataSource = _comprobanteSalon.ObtenerComprobantesPorCliente(_clienteId);
            FormatearGrilla2(dgvGrilla);

        }

        private void dgvGrilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvGrilla.RowCount > 0)
            {
                if (dgvGrilla.Rows[e.RowIndex].DataBoundItem is ClienteDto)
                {
                    return;
                }
               if(dgvGrilla.Rows[e.RowIndex].DataBoundItem is ComprobanteSalonDto)
                {
                    _comprobanteSalonDto = (ComprobanteSalonDto)dgvGrilla.Rows[e.RowIndex].DataBoundItem;

                    txtSaldarCtaCte.Text = _comprobanteSalonDto.Total.ToString();
                    txtSaldarCtaCte.Enabled = true;
                    btnSaldarCtaCte.Enabled = true;
                    txtTotal.Text = _comprobanteSalonDto.Total.ToString();
                }
                else
                {
                    _comprobanteDeliveryDto = (ComprobanteDeliveryDto)dgvGrilla.Rows[e.RowIndex].DataBoundItem;

                    txtSaldarCtaCte.Text = _comprobanteDeliveryDto.Total.ToString();
                    txtSaldarCtaCte.Enabled = true;
                    btnSaldarCtaCte.Enabled = true;
                    txtTotal.Text = _comprobanteDeliveryDto.Total.ToString();
                }
    


                }
            //banca, ya pruebo una cosa y conecto los auriculares asi lo pensamod juntos ok
        }

        private void btnSaldarCtaCte_Click(object sender, EventArgs e)
        {
            decimal aux = 0;
            aux = decimal.Parse(txtSaldarCtaCte.Text);

            if (_comprobanteSalonDto != null)
            {
                if (aux > _comprobanteSalonDto.Total)
                {
                    Mensaje.Mostrar("No puede pasarse del monto del comprobante", Mensaje.Tipo.Informacion);
                }
                else
                {
                    _comprobanteSalonDto.Total -= aux;
                    if (_comprobanteSalonDto.Total == 0)
                    {

                        _comprobanteSalon.QuitarComprobante(_comprobanteSalonDto.MesaId);
                        dgvGrilla.DataSource = _comprobanteSalon.ObtenerComprobantesPorCliente(_clienteId);
                        _comprobanteSalonDto = null;
                    }
                    FormatearGrilla2(dgvGrilla);
                }
                
            }

            if (_comprobanteDeliveryDto != null)
            {
                if (aux > _comprobanteDeliveryDto.Total)
                {
                    Mensaje.Mostrar("No puede pasarse del monto del comprobante", Mensaje.Tipo.Informacion);
                }
                else
                {
                    _comprobanteDeliveryDto.Total -= aux;
                    if (_comprobanteDeliveryDto.Total == 0)
                    {

                        _comprobanteDelivery.QuitarComprobante(_comprobanteDeliveryDto.ClienteId);
                        dgvGrilla.DataSource = _comprobanteDelivery.ObtenerComprobantesPorCliente(_clienteId);
                        _comprobanteDeliveryDto = null;
                    }
                    FormatearGrilla3(dgvGrilla);
                }
                
            }



        }
    }

    
}
