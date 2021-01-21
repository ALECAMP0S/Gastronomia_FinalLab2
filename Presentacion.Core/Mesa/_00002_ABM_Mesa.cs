using System;
using System.Windows.Forms;
using Presentacion.Base;
using Presentacion.Base.Varios;
using Servicio.Core.Mesa;

namespace Presentacion.Core.Mesa
{
    public partial class _00002_ABM_Mesa : FormularioABM
    {
        private readonly IMesaServicio _mesaServicio;

        public _00002_ABM_Mesa(string _tipoOperacion, long? _entidadId)
            :base(_tipoOperacion, _entidadId)
        {
            InitializeComponent();

            _mesaServicio = new MesaServicio();

            nudNumero.Enter += txt_Enter;
            nudNumero.Leave += txt_Leave;

            txtDescripcion.Enter += txt_Enter;
            txtDescripcion.Leave += txt_Leave;

            txtDescripcion.KeyPress += Validacion.NoSimbolos;
            txtDescripcion.KeyPress += Validacion.NoInyeccion;

            Init(_tipoOperacion, _entidadId);
        }

        public override void CargarDatos(long? _entidadId)
        {
            var mesa = _mesaServicio.ObtenerPorId(_entidadId.Value);

            nudNumero.Value = mesa.Numero;
            txtDescripcion.Text = mesa.Descripcion;
        }

        public override void LimpiarDatos(object obj)
        {
            base.LimpiarDatos(obj);

            txtDescripcion.Clear();
            txtDescripcion.Focus();
        }

        public override void ObtenerSiguienteCodigo()
        {
            nudNumero.Value = _mesaServicio.ObtenerSiguienteNumero();
        }

        public override bool VerificarSiExiste()
        {
            return _mesaServicio.VerificarSiExiste(entidadId, (int) nudNumero.Value, txtDescripcion.Text);
        }

        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                Mensaje.Mostrar("La descripción es Obligatoria", Mensaje.Tipo.Informacion);
                txtDescripcion.Focus();
                return false;
            }

            return true;
        }

        public override bool EjecutarComandoNuevo()
        {
            try
            {
                _mesaServicio.Insertar((int)nudNumero.Value, txtDescripcion.Text);
                Mensaje.Mostrar("Los datos se grabaron correctamente", Mensaje.Tipo.Informacion);
                return true;
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(ex.Message, Mensaje.Tipo.Stop);
            }

            return false;
        }

        public override bool EjecutarComandoModificar()
        {
            try
            {
                _mesaServicio.Modificar(entidadId.Value, (int)nudNumero.Value, txtDescripcion.Text);
                Mensaje.Mostrar("Los datos se modificaron correctamente", Mensaje.Tipo.Informacion);
                return true;
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(ex.Message, Mensaje.Tipo.Stop);
            }

            return false;
        }

        public override bool EjecutarComandoEliminar()
        {
            try
            {
                _mesaServicio.Eliminar(entidadId.Value);
                Mensaje.Mostrar("Los datos se eliminaron correctamente", Mensaje.Tipo.Informacion);
                return true;
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(ex.Message, Mensaje.Tipo.Stop);
            }

            return false;
        }
    }
}
