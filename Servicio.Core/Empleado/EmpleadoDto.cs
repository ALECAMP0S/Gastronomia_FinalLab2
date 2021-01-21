using System;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.Empleado
{
    public class EmpleadoDto
    {
        public long Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Dni { get; set; }
        public string Cuil { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public bool EstaEliminado { get; set; }
        public TipoEmpleado TipoEmpleado { get; set; }
        public int Legajo { get; set; }
        public bool EstaBloqueado { get; set; }
    }
}
