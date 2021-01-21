using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.Cliente
{
    public class ClienteDto
    {
        public long Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Dni { get; set; }
        public string Cuil { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public int Codigo { get; set; }
        public bool TieneCtaCte { get; set; }
        public decimal MontoMaximoCtaCte { get; set; }
    }
}
