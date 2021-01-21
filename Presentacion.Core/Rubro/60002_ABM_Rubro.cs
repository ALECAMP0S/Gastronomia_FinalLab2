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
using Servicio.Core.Rubro;
using Presentacion.Base.Varios;

namespace Presentacion.Core.Rubro
{
    public partial class _60002_ABM_Rubro : FormularioABM
    {
        private readonly IRubroServicio _rubroServicio;
        public _60002_ABM_Rubro(string _tipoOperacion, long? _entidadId)
            : base(_tipoOperacion, _entidadId)
        {
            InitializeComponent();

            _rubroServicio = new RubroServicio();

            nudCodigo.Enter += txt_Enter;
            nudCodigo.Leave += txt_Leave;

            txtDescripcion.Enter += txt_Enter;
            txtDescripcion.Leave += txt_Leave;

            txtDescripcion.KeyPress += Validacion.NoSimbolos;
            txtDescripcion.KeyPress += Validacion.NoInyeccion;
            txtDescripcion.KeyPress += Validacion.NoNumeros;

            Init(_tipoOperacion, _entidadId);
        }
        public override void CargarDatos(long? _entidadId)
        {
            var rubro = _rubroServicio.ObtenerPorId(_entidadId.Value);

            nudCodigo.Value = rubro.Codigo;
            txtDescripcion.Text = rubro.Descripcion;
        }
        public override void LimpiarDatos(object obj)
        {
            base.LimpiarDatos(obj);

            txtDescripcion.Clear();
            txtDescripcion.Focus();
        }

        public override void ObtenerSiguienteCodigo()
        {
            nudCodigo.Value = _rubroServicio.ObtenerSiguienteNumero();
        }

        public override bool VerificarSiExiste()
        {
            return _rubroServicio.VerificarSiExiste(entidadId, (int)nudCodigo.Value);
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
                _rubroServicio.Insertar(new RubroDto
                {
                    Codigo = (int)nudCodigo.Value,
                    Descripcion = txtDescripcion.Text
                }
                    );
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
                if (!VerificarSiExiste(entidadId.Value, (int)nudCodigo.Value))
                {
                    _rubroServicio.Modificar(new RubroDto
                    {
                        Id = entidadId.Value,
                        Codigo = (int)nudCodigo.Value,
                        Descripcion = txtDescripcion.Text
                    });
                    Mensaje.Mostrar("Los datos se modificaron correctamente", Mensaje.Tipo.Informacion);
                    return true;
                }
                else
                {
                    Mensaje.Mostrar("Los datos cargados ya existen.", Mensaje.Tipo.Advertencia);

                }
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(ex.Message, Mensaje.Tipo.Stop);
            }

            return false;
        }

        private bool VerificarSiExiste(long rubroId, int codigo)
        {
            return _rubroServicio.VerificarSiExiste(rubroId, codigo);
        }

        public override bool EjecutarComandoEliminar()
        {
            try
            {
                if (!VerificarSiExiste(entidadId.Value, (int)nudCodigo.Value))
                {
                    _rubroServicio.Eliminar(new RubroDto
                    {
                        Id = entidadId.Value
                    });
                    Mensaje.Mostrar("Los datos se eliminaron correctamente", Mensaje.Tipo.Informacion);
                    return true;
                }

                else
                {
                    Mensaje.Mostrar("Los datos cargados ya existen.", Mensaje.Tipo.Advertencia);

                }
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(ex.Message, Mensaje.Tipo.Stop);
            }

            return false;
        }
    }
}
