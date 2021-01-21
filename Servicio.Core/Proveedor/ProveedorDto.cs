using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.Proveedor
{
    public class ProveedorDto
    {
        public long Id { get; set; }
        public string NombreFantacia { get; set; }
        public string Telefono { get; set; }
        public string Cuil { get; set; }
        public string Direccion { get; set; }
        public bool EstaEliminado { get; set; }
        public bool EstaBloqueado { get; set; }
        public long CondicionIva { get; set; }
        public string ApyNomContacto
        {
            get { return NombreFantacia + " " + RazonSocial + " " + Telefono; }

        }
        public string IngresosBrutos { get; set; }
        public DateTime FechaIncioActividad { get; set; }
        public string RazonSocial { get; set; }
    }
}
