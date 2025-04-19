using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Pasaje> _pasajes = new List<Pasaje>();
        private List<Vuelo> _vuelos = new List<Vuelo>();
        private List<Ruta> _rutas = new List<Ruta>();
        private List<Avion> _aviones = new List<Avion>();
        private List<Aeropuerto> _aeropuertos = new List<Aeropuerto>();

        public void AltaAviones(Avion avion)
        {
            avion.ValidarAvion();
            if (!_aviones.Contains(avion))
            {
                _aviones.Add(avion);
            }
        }

        public void AltaAeropuertos(Aeropuerto aeropuerto)
        {
            aeropuerto.ValidarAeropuerto();
            if (!_aeropuertos.Contains(aeropuerto))
            {
                _aeropuertos.Add(aeropuerto);
            }
            else
            {
                Console.WriteLine("Ya existe un aeropuerto con este codigo IATA");
            }
        }

        public void AltaRutas(Ruta ruta)
        {
            ruta.ValidarRuta();
            if(!_rutas.Contains(ruta))
            {
                _rutas.Add(ruta);
            }
            else
            {
                Console.WriteLine("Ya existe una ruta con ese id");
            }
        }
    }
}
