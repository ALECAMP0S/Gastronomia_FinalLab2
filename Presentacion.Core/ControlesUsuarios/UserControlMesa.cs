using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DAL;
using Presentacion.Base.Varios;
using Presentacion.Core.Facturacion;
using Presentacion.Core.Venta_en_Salon;
using Servicio.Core.ComprobanteSalon;
using Servicio.Core.Mesa;
using Presentacion.Core.Reservacion;
using Servicio.Core.ComprobanteReserva;
using System;

namespace Presentacion.Core.ControlesUsuarios
{
    public partial class UserControlMesa : UserControl
    {
        // Atributos
        private long _id;
        private ComprobanteReservaDto _comprobante;
        private long _mozoId;
        private readonly IMesaServicio _mesaServicio;
        private readonly IComprobanteSalon _comprobanteSalon;
        private readonly IComprobanteReserva _comprobanteReserva;
        public long idp => _id;

        // Propiedades 
        public long MozoId
        {
            set { _mozoId = value; }
        }
        public long Id {
            set { _id = value; }
        }

        

        private EstadoMesa _estado;
        public EstadoMesa EstadoMesa
        {
            set 
            {
                _estado = value;

                switch (value)
                {
                    case EstadoMesa.Libre:
                        pnlEstado.BackColor = Color.GreenYellow;
                        separador.Visible = false;
                        cambiarDeMesaToolStripMenuItem.Visible = false;
                        cerrarMesaToolStripMenuItem.Visible = false;
                        abrirMesaToolStripMenuItem.Visible = true;
                        combinarMesaToolStripMenuItem.Visible = false;
                        reservaActivaToolStripMenuItem.Visible = true;
                        break;
                    case EstadoMesa.Reservada:
                        pnlEstado.BackColor = Color.Orange;
                        separador.Visible = false;
                        cambiarDeMesaToolStripMenuItem.Visible = false;
                        cerrarMesaToolStripMenuItem.Visible = false;
                        abrirMesaToolStripMenuItem.Visible = true;
                        combinarMesaToolStripMenuItem.Visible = false;
                        reservarToolStripMenuItem.Visible = false;
                        break;
                    case EstadoMesa.Ocupada:
                        pnlEstado.BackColor = Color.Red;
                        separador.Visible = true;
                        cambiarDeMesaToolStripMenuItem.Visible = true;
                        cerrarMesaToolStripMenuItem.Visible = true;
                        abrirMesaToolStripMenuItem.Visible = false;
                        combinarMesaToolStripMenuItem.Visible = true;
                        reservarToolStripMenuItem.Visible = false;
                        break;
                    case EstadoMesa.Combinada:
                        pnlEstado.BackColor = Color.Blue;
                        separador.Visible = false;
                        cambiarDeMesaToolStripMenuItem.Visible = false;
                        cerrarMesaToolStripMenuItem.Visible = true;
                        abrirMesaToolStripMenuItem.Visible = false;
                        combinarMesaToolStripMenuItem.Visible = false;
                        reservarToolStripMenuItem.Visible = false;
                        break;
                }
            }
        }

        public decimal Total
        {
            set { lblTotal.Text = value.ToString("C2"); }
        }

        public int Numero
        {
            set { lblNumeroMesa.Text = value.ToString(); }
        }

        public UserControlMesa()
        {
            InitializeComponent();
            _mesaServicio = new MesaServicio();
            _comprobanteSalon = new ComprobanteSalon();
            _comprobanteReserva = new ComprobanteReserva();
        }
        private void VerificarReserva()
        {
            if (_comprobante != null)
            {

                    Mensaje.Mostrar("Se reservo la mesa", Mensaje.Tipo.Informacion);
                    _mesaServicio.CambiarEstado(_id, EstadoMesa.Reservada);
                    EstadoMesa = EstadoMesa.Reservada;
                    
            }
           
        }
        private void lblNumeroMesa_DoubleClick(object sender, System.EventArgs e)
        {
            if (_estado == EstadoMesa.Ocupada || _estado == EstadoMesa.Combinada)
            {
                var formulario = new _10002_Venta(_id);
                formulario.ShowDialog();
                var comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_id);
                if (comprobante.ComprobanteSalonDetalleDtos != null)
                {
                    Total = comprobante.ComprobanteSalonDetalleDtos.Any()
                        ? comprobante.ComprobanteSalonDetalleDtos.Sum(x => x.SubTotal)
                        : 0m;
                }
            }
            else
            {
                Mensaje.Mostrar("La mesa no esta abierta", Mensaje.Tipo.Informacion);
            }

        }

        private void abrirMesaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var mesa = _mesaServicio.ObtenerPorId(_id);

            if (mesa.EstadoMesa == EstadoMesa.Libre)
            {
                _mesaServicio.CambiarEstado(_id, EstadoMesa.Ocupada);
                EstadoMesa = EstadoMesa.Ocupada;
                _comprobanteSalon.Crear(_id, null);
            }
            

        }

        private void cerrarMesaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var comprobante =_comprobanteSalon.ObtenerComprobantePorMesa(_id);
            if (comprobante.Total == 0)
            {
                _mesaServicio.CambiarEstado(_id, EstadoMesa.Libre);
                EstadoMesa = EstadoMesa.Libre;
                Total = 0m;
            }
            else
            {
                var pagarFactura = new _10003_FormaDePago(_id);
                pagarFactura.ShowDialog();
                if (pagarFactura.realizoOperacion == false)
                {
                    _mesaServicio.CambiarEstado(_id, EstadoMesa.Libre);
                    EstadoMesa = EstadoMesa.Libre;
                    Total = 0m;
                }
            }
                

        }

        private void cambiarDeMesaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var mesaId = _id;

            var cambioDeMesas = new CambiarMesa(_id);

            cambioDeMesas.ShowDialog();
            if (cambioDeMesas.realizoAlgunaOperacion)
            {


                var mesa = _mesaServicio.ObtenerPorId(cambioDeMesas._mesaId);
                if (mesa.EstadoMesa != EstadoMesa.Ocupada)
                {
                    if (mesaId != cambioDeMesas._mesaId)
                    {
                        _comprobanteSalon.CambiarMesa(mesaId, cambioDeMesas._mesaId);
                        _mesaServicio.CambiarEstado(cambioDeMesas._mesaId, EstadoMesa.Ocupada);

                        _mesaServicio.CambiarEstado(mesaId, EstadoMesa.Libre);

                        EstadoMesa = EstadoMesa.Libre;
                        Total = 0m;
                    }
                    else
                    {
                        Mensaje.Mostrar("No se puede cambiar a la mesa de origen", Mensaje.Tipo.Informacion);
                    }
                }
                else
                {
                    Mensaje.Mostrar("La mesa de destino esta ocupada", Mensaje.Tipo.Informacion);

                }
            }


        }

        private void reservaActivaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            
            var mesa = _mesaServicio.ObtenerPorId(_id);
            if (mesa.EstadoMesa != EstadoMesa.Ocupada)
            {
                var reserva = new ABM_Reservacion(_id);
                reserva.ShowDialog();
                if (reserva._realizoReserva == true)
                {
                    _comprobante = _comprobanteReserva.ObtenerComprobantePorCliente(reserva._clienteId);
                }
                VerificarReserva();
            }
            else
            {
                Mensaje.Mostrar("La mesa esta ocupada", Mensaje.Tipo.Informacion);
            }
        }

        private void reservaConfirmadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_comprobante != null)
            {
                _comprobanteReserva.QuitarComprobante(_comprobante.Id);
                _mesaServicio.CambiarEstado(_id, EstadoMesa.Ocupada);
                EstadoMesa = EstadoMesa.Ocupada;
            }
            
        }

        private void reservaCanceladaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_comprobante != null)
            {
                _comprobanteReserva.QuitarComprobante(_comprobante.Id);
                _mesaServicio.CambiarEstado(_id, EstadoMesa.Ocupada);
                EstadoMesa = EstadoMesa.Libre;
            }
           
        }

        private void combinarMesaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var mesas = _mesaServicio.ObtenerMesasOcupadas();

            if (mesas.Count() < 2)
            {
                Mensaje.Mostrar("No hay suficientes mesas para combinar, abra 2 o mas mesas", Mensaje.Tipo.Informacion);
            }
            else
            {
                var combinar = new CombinarMesas();
                combinar.ShowDialog();
                if (combinar.realizoOperacion)
                {
                    EstadoMesa = EstadoMesa.Libre;

                }

            }

        }
    }
}
