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
        private double _costoOperacion;
        private double _costoTasas;

        public Aeropuerto(string codigoIATA, string ciudad, double costoOperacion, double costoTasas)
        {
            _codigoIATA = codigoIATA;
            _ciudad = ciudad;
            _costoOperacion = costoOperacion;
            _costoTasas = costoTasas;
        }
    }
}
