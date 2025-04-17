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

        //Para validar usuarios de cualquier tipo hay que preguntar a la profe.
    }
}
