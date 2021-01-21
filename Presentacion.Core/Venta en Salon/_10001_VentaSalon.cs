using System;
using System.Windows.Forms;
using Presentacion.Core.ControlesUsuarios;
using Servicio.Core.SalonMesa;
using Servicio.Core.ComprobanteSalon;
using Servicio.Core.Mesa;
using System.Linq;

namespace Presentacion.Core.Venta_en_Salon
{
    public partial class _10001_VentaSalon : Form
    {
        private readonly ISaloMesaServicio _salonMesaServicio;
        private readonly IComprobanteSalon _comprobanteSalon;
        private readonly IMesaServicio _mesaServicio;
        public _10001_VentaSalon(ISaloMesaServicio salonMesaServicio)
        {
            InitializeComponent();
            _comprobanteSalon = new ComprobanteSalon();
            _mesaServicio = new MesaServicio();
            _salonMesaServicio = salonMesaServicio;
        }

        public _10001_VentaSalon()
            : this(new SaloMesaServicio())
        {
            CargarMesas();
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

        public void CargarMesas()
        {
            // Obtengo las mesas para el salon de venta
            var mesas = _salonMesaServicio.ObtenerMesasParaSalon();

            foreach (var mesa in mesas)
            {
                var ctrolMesa = new UserControlMesa
                {
                    EstadoMesa = mesa.EstadoMesa,
                    Total = mesa.Total,
                    Numero = mesa.Numero,
                    Id = mesa.Id
                };
                
                Contenedor.Controls.Add(ctrolMesa);
            }
        }
        private decimal CargarTotal(long id)
        {
            var comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(id);
            if (comprobante !=null)
            {
                if (comprobante.ComprobanteSalonDetalleDtos != null)
                {
                    return comprobante.ComprobanteSalonDetalleDtos.Any()
                        ? comprobante.ComprobanteSalonDetalleDtos.Sum(x => x.SubTotal)
                        : 0m;
                }
            }
            //ActualizarMesas();
            

            return 0m;

        }
        public void ActualizarMesas()
        {
            // Obtengo las mesas para el salon de venta
            var mesas = _salonMesaServicio.ObtenerMesasParaSalon();


            foreach (var control in Contenedor.Controls.OfType<UserControlMesa>())
            {
                if (control.idp != null)
                {
                    control.Total = CargarTotal(control.idp);
                    control.EstadoMesa = _mesaServicio.ObtenerEstadoMesa(control.idp);
                }
                
            }
        }
        private void _10001_VentaSalon_Load(object sender, EventArgs e)
        {
        }

        private void Contenedor_Enter(object sender, EventArgs e)
        {
            ActualizarMesas();
        }

        private void Contenedor_Click(object sender, EventArgs e)
        {
            ActualizarMesas();
        }
    }
}
