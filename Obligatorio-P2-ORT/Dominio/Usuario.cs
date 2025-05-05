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

        public void ValidarUsuario()
        {
            if (string.IsNullOrEmpty(_correoElectronico))
            {
                throw new Exception("El correo electronico no puede estar vacio");
            }
            if (string.IsNullOrEmpty(_contrasenia))
            {
                throw new Exception("La contraseña no puede estar vacia");
            }
        }

        public override bool Equals(object? obj)
        {
            bool sonIguales = false;

            if (obj != null && obj is Usuario) 
            { 
                Usuario usuario = (Usuario)obj;
                sonIguales = _correoElectronico ==  usuario._correoElectronico;
            }

            return sonIguales;
        }
    }
}
