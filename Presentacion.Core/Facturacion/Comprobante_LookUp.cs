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
using Servicio.Core.ComprobanteSalon;

namespace Presentacion.Core.Facturacion
{
    public partial class Comprobante_LookUp : FormularioBase
    {
        private readonly IComprobanteSalon _comprobanteSalon;
        private long _mesaId;
        private ComprobanteSalonDto _comprobante;
        public Comprobante_LookUp(long mesaId)
            :this(new ComprobanteSalon())
        {
            InitializeComponent();
            _mesaId = mesaId;
        }
        public Comprobante_LookUp(IComprobanteSalon comprobanteSalon)
        {
            _comprobanteSalon = comprobanteSalon;
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
            _comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_mesaId);
            nudTOTAL.Value = _comprobante.ComprobanteSalonDetalleDtos.Sum(x=> x.SubTotal);
            dgvGrilla.DataSource = _comprobante.ComprobanteSalonDetalleDtos.ToList();
            FormatearGrilla(dgvGrilla);
        }

        private void Comprobante_LookUp_Load(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }
    }
}
