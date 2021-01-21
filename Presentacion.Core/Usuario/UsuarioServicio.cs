
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Presentacion.Core.Usuario
{
    public class UsuarioServicio : IUsuarioServicio
    {
        public bool Autenticar(string password, string nombre)
        {
            try
            {
                using (var conetxt = new ModeloGastronomiaContainer())
                {
                    return conetxt.Usuarios.Any(x => x.Password == password
                                                     && x.EstaBloqueado == false
                                                     && x.Nombre == nombre);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
