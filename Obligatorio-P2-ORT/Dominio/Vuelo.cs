using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Vuelo
    {
        private string _numeroVuelo;
        private Frecuencia _frecuencia;
        private Ruta _ruta;
        private Avion _avion;

        public Vuelo (string numeroVuelo, Frecuencia frecuencia, Ruta ruta, Avion avion)
        {
            _numeroVuelo = numeroVuelo;
            _frecuencia = frecuencia;
            _ruta = ruta;
            _avion = avion;
        }
    }
}
