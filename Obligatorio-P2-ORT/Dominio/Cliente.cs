using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Cliente:Usuario
    {
        private string _nombre;
        private string _documento;
        private string _nacionalidad;

        public Cliente(string correoElectronico, string contrasenia, string nombre, string documento, string nacionalidad)
            : base (correoElectronico, contrasenia)
        {
            _nombre = nombre;
            _documento = documento;
            _nacionalidad = nacionalidad;
        }


    }
}
