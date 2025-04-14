using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador:Usuario
    {
        private string _apodo;

        public Administrador(string correoElectronico, string contrasenia, string apodo) 
            : base (correoElectronico, contrasenia)
        {
            _apodo = apodo;
        }
    }
}
