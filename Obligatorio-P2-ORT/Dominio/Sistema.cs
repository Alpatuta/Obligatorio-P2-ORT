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
                throw new Exception("Ya existe un aeropuerto con este codigo IATA");
            }
        }

        public void AltaRutas(Ruta ruta)
        {
            ruta.ValidarRuta();
            if (!_rutas.Contains(ruta))
            {
                _rutas.Add(ruta);
            }
            else
            {
                throw new Exception("Ya existe una ruta con ese id");
            }
        }

        public void AltaVuelos(Vuelo vuelo)
        {
            vuelo.ValidarVuelo();
            if (!_vuelos.Contains(vuelo))
            {
                _vuelos.Add(vuelo);
            }
            else
            {
                throw new Exception("Ya existe un vuelo con ese numero de vuelo");
            }
        }

        public void AltaPasajes(Pasaje pasaje)
        {
            pasaje.ValidarPasaje();
            if (!_pasajes.Contains(pasaje))
            {
                _pasajes.Add(pasaje);
            }
            else
            {
                throw new Exception("Ya existe un pasaje con ese Id");
            }
        }

        public void AltaUsuarioClientePremium(Premium premium)
        {
            premium.Validar();
            if (!_usuarios.Contains(premium))
            {
                _usuarios.Add(premium);
            }
            else
            {
                throw new Exception("Ya existe ese cliente premium");
            }
        }

        public void AltaUsuarioClienteOcasional(Ocasional ocasional)
        {
            ocasional.Validar();
            if (!_usuarios.Contains(ocasional))
            {
                _usuarios.Add(ocasional);
            }
            else
            {
                throw new Exception("Ya existe ese cliente ocasional");
            }
        }

        public void AltaUsuarioAdministrador(Administrador admin)
        {
            admin.Validar();
            if (!_usuarios.Contains(admin))
            {
                _usuarios.Add(admin);
            }
            else
            {
                throw new Exception("Ya existe ese usuario administrador");
            }
        }
    }
}


