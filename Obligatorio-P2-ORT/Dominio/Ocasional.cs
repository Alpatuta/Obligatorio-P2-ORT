using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ocasional : Cliente
    {
        private bool _esElegible;

        public Ocasional(string correoElectronico, string contrasenia, string nombre, string documento, string nacionalidad)
            : base(correoElectronico, contrasenia, nombre, documento, nacionalidad)
        {
            
            _esElegible = esElegible();
        }

        public Ocasional() : base() { }

        public bool EsElegible
        {
            get { return _esElegible; }
            set { _esElegible = value; }
        }

        private static bool esElegible()
        {
            Random random = new Random();
            int nRandom = random.Next(0, 1);

            bool esElegible = false;

            if (nRandom == 1)
            {
                esElegible = true;
            }

            return esElegible;
        }
        public void Validar()
        {
            base.ValidarCliente();
        }

        public override string ToString()
        {
            string elegible = "No";

            if (_esElegible)
            {
                elegible = "Si";
            }

            return elegible;
        }

        public override double CostoSegunCliente(double costoBase, Equipaje equipaje)
        {
            
            if ((int)equipaje == 1)
            {
                costoBase *= 1.10;      
            }
            else if((int)equipaje == 2)
            {
                costoBase *= 1.20;
            }

            return costoBase;
        }
    }
}
