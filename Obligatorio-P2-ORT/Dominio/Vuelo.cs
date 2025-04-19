using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vuelo
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

        public void ValidarVuelo()
        {
            if(string.IsNullOrEmpty(_numeroVuelo))
            {
                throw new Exception("El numero de vuelo no puede ser vacio");
            }

            if(_ruta == null)
            {
                throw new Exception("El vuelo debe tener asignada una ruta");
            }

            if(_avion == null)
            {
                throw new Exception("El vuelo debe tener un avion asignado");
            }

            if(_frecuencia != 0)
            {
                //Preguntarle a la profe validacion de enum
            }
        }
    }
}
