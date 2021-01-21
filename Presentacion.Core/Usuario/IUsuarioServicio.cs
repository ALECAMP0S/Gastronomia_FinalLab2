using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Core.Usuario
{
    public interface IUsuarioServicio
    {
        bool Autenticar(string password, string nombre);
    }
}
