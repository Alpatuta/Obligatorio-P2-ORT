using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Aeropuerto
    {
        private string _codigoIATA;
        private string _ciudad;
        private double _costoOperacionAeropuerto;
        private double _costoTasas;

        public Aeropuerto(string codigoIATA, string ciudad, double costoOperacion, double costoTasas)
        {
            _codigoIATA = codigoIATA;
            _ciudad = ciudad;
            _costoOperacionAeropuerto = costoOperacion;
            _costoTasas = costoTasas;
        }

        public void ValidarAeropuerto() 
        { 
            if(string.IsNullOrEmpty(_codigoIATA) || _codigoIATA.Length != 3)
            {
                throw new Exception("El codigo IATA debe ser de 3 letras de largo");
                //Validar que sean letras nomas, pregunatrle a la profe.
            }

            if (string.IsNullOrEmpty(_ciudad))
            {
                throw new Exception("Ingresar una ciudad");
            }

            if(_costoOperacionAeropuerto  <= 0)
            {
                throw new Exception("El costo de operacion debe ser mayor a cero");
            }

            if(_costoTasas <= 0)
            {
                throw new Exception("El costo de las tasas debe ser mayor a cero");
            }
        }
    }
}
