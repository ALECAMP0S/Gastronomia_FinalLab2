using Presentacion.Base;
using Presentacion.Base.Varios;
using Presentacion.Core.Cliente;
using Presentacion.Core.Mozo;
using Servicio.Core.Cliente;
using Servicio.Core.ComprobanteReserva;
using Servicio.Core.Empleado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Reservacion
{
    public partial class ABM_Reservacion : FormularioBase
    {
        public long _mesaId;
        public long _clienteId;
        public long _empleadoId;
        public bool _realizoReserva;
        private readonly IComprobanteReserva _comprobanteReserva;
        public ABM_Reservacion(long mesaId)
            : this(new ComprobanteReserva())
        {
            _realizoReserva = false;
            _mesaId = mesaId;
            

            InitializeComponent();
            txtCantCom.KeyPress += Validacion.NoSimbolos;
            txtCantCom.KeyPress += Validacion.NoInyeccion;
            txtCantCom.KeyPress += Validacion.NoLetras;

            txtMonto.KeyPress += Validacion.NoSimbolos;
            txtMonto.KeyPress += Validacion.NoInyeccion;
            txtMonto.KeyPress += Validacion.NoLetras;
        }
        public ABM_Reservacion(IComprobanteReserva comprobanteReserva)
        {
            _comprobanteReserva = comprobanteReserva;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            var lookUpProducto = new Cliente_LookUp();
            lookUpProducto.ShowDialog();
            if (lookUpProducto.Entidad != null)
            {
                var EmpleadoSeleccionado = (ClienteDto)lookUpProducto.Entidad;
                txtCliente.Text = EmpleadoSeleccionado.Apellido + " " + EmpleadoSeleccionado.Nombre;
                _clienteId = EmpleadoSeleccionado.Id;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var lookUpProducto = new Mozo_LookUp();
            lookUpProducto.ShowDialog();
            if (lookUpProducto.Entidad != null)
            {
                var EmpleadoSeleccionado = (EmpleadoDto)lookUpProducto.Entidad;
                txtEmpleado.Text = EmpleadoSeleccionado.Apellido + " " + EmpleadoSeleccionado.Nombre;
                _empleadoId = EmpleadoSeleccionado.Id;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCliente.Text))
            {
                Mensaje.Mostrar("Elija un cliente", Mensaje.Tipo.Informacion);
                return;
            }
            if (string.IsNullOrEmpty(txtCliente.Text))
            {
                Mensaje.Mostrar("Elija un Empleado", Mensaje.Tipo.Informacion);
                return;
            }
            if (string.IsNullOrEmpty(txtCantCom.Text))
            {
                Mensaje.Mostrar("Ingrese una cantidad de comensales", Mensaje.Tipo.Informacion);
                return;
            }
            if (string.IsNullOrEmpty(txtMonto.Text))
            {
                Mensaje.Mostrar("Ingrese una senia", Mensaje.Tipo.Informacion);
                return;
            }
            if (string.IsNullOrEmpty(txtObservacion.Text))
            {
                Mensaje.Mostrar("Ingrese una observacion", Mensaje.Tipo.Informacion);
                return;
            }

            var datetime = dateTimePicker1.Value.AddMinutes(-30);
            _comprobanteReserva.Crear(_mesaId, new ComprobanteReservaDto
            {
                FechaReserva = datetime,
                ClienteId = _clienteId,
                EmpleadoId = _empleadoId,
                CantidadComensales = int.Parse(txtCantCom.Text),
                MontoSenia = int.Parse(txtMonto.Text),
                Observacion = txtObservacion.Text
            });
            _realizoReserva = true;
            Close();
        }

        private void ABM_Reservacion_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";
        }
    }
}
