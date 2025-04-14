using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Premium:Cliente
    {
        private int _puntos;

        public Premium(string correoElectronico, string contrasenia, string nombre, string documento, string nacionalidad, int puntos) 
            : base(correoElectronico, contrasenia, nombre, documento, nacionalidad) 
        { 
            _puntos = puntos;
        }
    }
}
