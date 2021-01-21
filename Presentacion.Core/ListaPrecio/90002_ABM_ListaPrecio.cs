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
using Servicio.Core.ListaPprecio;
using Presentacion.Base.Varios;

namespace Presentacion.Core.ListaPrecio
{
    public partial class _90002_ABM_ListaPrecio : FormularioABM
    {
        private readonly IListaPrecioServicio _listaPrecioServicio;

        public _90002_ABM_ListaPrecio()
        {
            InitializeComponent();
        }

        public _90002_ABM_ListaPrecio(string _tipoOperacion, long? _entidadId = default(long?))
            : base(_tipoOperacion, _entidadId)
        {

            InitializeComponent();
            _listaPrecioServicio = new ListaPrecioServicio();

            nudNumero.Enter += txt_Enter;
            nudNumero.Leave += txt_Leave;

            txtDescripcion.Enter += txt_Enter;
            txtDescripcion.Leave += txt_Leave;

            txtDescripcion.KeyPress += Validacion.NoSimbolos;
            txtDescripcion.KeyPress += Validacion.NoInyeccion;

            Init(_tipoOperacion, entidadId);
        }
        public override void LimpiarDatos(object obj)
        {
            base.LimpiarDatos(obj);
            ObtenerSiguienteCodigo();
        }
        private void ObtenerSiguienteCodigo()
        {
            nudNumero.Value = _listaPrecioServicio.ObtenerSiguienteLegajo();
        }
        public override void CargarDatos(long? entidadId)
        {
            try
            {
                var empleado = _listaPrecioServicio.ObtenerPorId(entidadId.Value);


                nudNumero.Value = empleado.Codigo;
                txtDescripcion.Text = empleado.Descripcion;

            }
            catch (ArgumentNullException exNull)
            {
                Mensaje.Mostrar("Hubo un error", Mensaje.Tipo.Informacion);
                nudNumero.Focus();
            }

        }
        public override bool EjecutarComandoNuevo()
        {
            try
            {
                _listaPrecioServicio.Insertar(new ListaPrecioDto
                {
                    Codigo = (int)nudNumero.Value,
                    Descripcion = txtDescripcion.Text

                });

                Mensaje.Mostrar("Los datos se grabaron Correctamente.", Mensaje.Tipo.Informacion);
                return true;
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar("Hubo un error al cargar los datos", Mensaje.Tipo.Error);
            }
            return false;
        }
        public override bool EjecutarComandoModificar()
        {
            try
            {
                if (!VerificarSiExiste(entidadId.Value, (int)nudNumero.Value))
                {
                    _listaPrecioServicio.Modificar(new ListaPrecioDto
                    {
                        Id = entidadId.Value,
                        Codigo = (int)nudNumero.Value,
                        Descripcion = txtDescripcion.Text
                    });

                    Mensaje.Mostrar("Los datos se grabaron Correctamente.", Mensaje.Tipo.Informacion);
                    return true;
                }
                else
                {
                    Mensaje.Mostrar("Los datos cargados ya existen.", Mensaje.Tipo.Advertencia);
                }

            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(ex.Message, Mensaje.Tipo.Error);
            }
            return false;
        }
        public override bool EjecutarComandoEliminar()
        {
            try
            {
                _listaPrecioServicio.Eliminar(new ListaPrecioDto
                {
                    Id = entidadId.Value,

                });

                Mensaje.Mostrar("Los datos se eliminaron Correctamente.", Mensaje.Tipo.Informacion);
                return true;
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(ex.Message, Mensaje.Tipo.Error);
            }
            return false;
        }
        private bool VerificarSiExiste(long? empleadoId, int legajo)
        {
            return _listaPrecioServicio.VerificarSiExiste(empleadoId, legajo);
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
    }
}
