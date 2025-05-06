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

        public Premium(string correoElectronico, string contrasenia, string nombre, string documento, string nacionalidad) 
            : base(correoElectronico, contrasenia, nombre, documento, nacionalidad) { }

        public void Validar()
        {
            //Los puentos serian static y empezarian en 0?? o se le asignan como dato solicitado??
            base.ValidarCliente();
        }
    } 
}
