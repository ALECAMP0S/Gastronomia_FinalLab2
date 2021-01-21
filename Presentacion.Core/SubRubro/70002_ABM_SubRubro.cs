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
using Servicio.Core.SubRubro;
using Servicio.Core.Rubro;
using Presentacion.Base.Varios;

namespace Presentacion.Core.SubRubro
{
    public partial class _70002_ABM_SubRubro : FormularioABM
    {
        private readonly ISubRubroServicio _subRubroServicio;
        private readonly IRubroServicio _rubroServicio;
        public _70002_ABM_SubRubro(string _tipoOperacion, long? _entidadId)
            : base(_tipoOperacion, _entidadId)
        {
            InitializeComponent();

            _subRubroServicio = new SubRubroServicio();
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

        private void CargarComboRubro()
        {
            PoblarComboBox(cmbRubro, _rubroServicio.ObtenerTodo(), "Descripcion", "Codigo");
        }

        public override void CargarDatos(long? _entidadId)
        {
            var rubro = _subRubroServicio.ObtenerPorId(_entidadId.Value);

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
            nudCodigo.Value = _subRubroServicio.ObtenerSiguienteNumero();
        }

        public override bool VerificarSiExiste()
        {
            return _subRubroServicio.VerificarSiExiste(entidadId, (int)nudCodigo.Value);
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
                _subRubroServicio.Insertar(new SubRubroDto
                {
                    Codigo = (int)nudCodigo.Value,
                    Descripcion = txtDescripcion.Text,
                    RubroId = cmbRubro.SelectedIndex + 1

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
                    _subRubroServicio.Modificar(new SubRubroDto
                    {
                        Id = entidadId.Value,
                        Codigo = (int)nudCodigo.Value,
                        Descripcion = txtDescripcion.Text,
                        RubroId = cmbRubro.SelectedIndex + 1
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
            return _subRubroServicio.VerificarSiExiste(rubroId, codigo);
        }

        public override bool EjecutarComandoEliminar()
        {
            try
            {
                if (!VerificarSiExiste(entidadId.Value, (int)nudCodigo.Value))
                {
                    _subRubroServicio.Eliminar(new SubRubroDto
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
        private void _70002_ABM_SubRubro_Load_1(object sender, EventArgs e)
        {
            CargarComboRubro();

        }
    }
}
