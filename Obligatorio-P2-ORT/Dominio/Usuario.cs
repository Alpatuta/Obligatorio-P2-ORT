using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Usuario
    {
        private string _correoElectronico;
        private string _contrasenia;

        public Usuario(string correoElectronico, string contrasenia)
        {
            _correoElectronico = correoElectronico;
            _contrasenia = contrasenia;
        }
    }
}
