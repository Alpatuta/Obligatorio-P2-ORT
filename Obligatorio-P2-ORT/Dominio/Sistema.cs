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

        // ALTAS DE OBJETOS
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
            admin.ValidarAdmin();
            if (!_usuarios.Contains(admin))
            {
                _usuarios.Add(admin);
            }
            else
            {
                throw new Exception("Ya existe ese usuario administrador");
            }
        }

        // BUSQUEDAS DE OBJETOS
        public Aeropuerto BuscarAeropuerto(string codigoIata)
        {
            Aeropuerto aeropuerto = null;
            int i = 0;

            while (i < _aeropuertos.Count && aeropuerto == null)
            {
                if (_aeropuertos[i].CodigoIata == codigoIata)
                {
                    aeropuerto = _aeropuertos[i];
                }

                i++;
            }

            return aeropuerto;
        }

        public Avion BuscarAvion(int id) 
        { 
            Avion avion = null;
            int i = 0;

            while (i < _aviones.Count && avion == null)
            {
                if (_aviones[i].Id == id)
                {
                    avion = _aviones[i];
                }

                i++;
            }

            return avion;
        }

        public Ruta BuscarRuta(int idRuta)
        {
            Ruta ruta = null;
            int i = 0;

            while (i < _rutas.Count && ruta == null)
            {
                if (_rutas[i].IdRuta == idRuta)
                {
                    ruta = _rutas[i];
                }
                i++;
            }

            return ruta;
        }

        public Vuelo BuscarVuelo(string numVuelo)
        {
            Vuelo vuelo = null;
            int i = 0;

            while (i < _vuelos.Count && vuelo == null)
            {
                if ( _vuelos[i].NumeroVuelo == numVuelo)
                {
                    vuelo = _vuelos[i];
                }

                i++;
            }

            return vuelo;
        }

        public Pasaje BuscarPasaje(int idPasaje)
        {
            Pasaje pasaje = null;
            int i = 0;

            while (i < _pasajes.Count && pasaje == null)
            {
                if (_pasajes[i].IdPasaje  == idPasaje)
                {
                    pasaje = _pasajes[i];
                }

                i++;
            }

            return pasaje;
        }

        public Usuario BuscarUsuarioCliente (string mail)
        {
            Usuario usuario = null;
            int i = 0;

            while (i < _usuarios.Count && usuario == null)
            {
                if (_usuarios[i] is Cliente && _usuarios[i].Mail == mail)
                {
                    usuario = _usuarios[i];
                }

                i++;
            }

            return usuario;
        }

        // PRECARGAS

        public void PrecargaUsuario()
        {
            PrecargaUsuariosAdmin();
            PrecargaUsuarioClientePremium();
        }

        private void PrecargaUsuariosAdmin()
        {
            AltaUsuarioAdministrador(new Administrador("admin1@gmail.com", "1234", "admin1"));
            AltaUsuarioAdministrador(new Administrador("admin2@gmail.com", "1234", "admin2"));
        }

        private void PrecargaUsuarioClientePremium()
        {
            AltaUsuarioClientePremium(new Premium("premium1@gmail.com", "1234", "premium1", "12345678", "Uruguay"));
            AltaUsuarioClientePremium(new Premium("premium2@gmail.com", "1234", "premium2", "23456789", "España"));
            AltaUsuarioClientePremium(new Premium("premium3@gmail.com", "1234", "premium3", "34567890", "España"));
            AltaUsuarioClientePremium(new Premium("premium4@gmail.com", "1234", "premium4", "45678901", "Japon"));
            AltaUsuarioClientePremium(new Premium("premium5@gmail.com", "1234", "premium5", "56789012", "Uruguay"));
        }

        private void PrecargaUsuarioClienteOcasional()
        {
            AltaUsuarioClienteOcasional(new Ocasional("ocasional1@gmail.com", "1234", "ocasional1", "67890123", "Uruguay", true));
            AltaUsuarioClienteOcasional(new Ocasional("ocasional2@gmail.com", "1234", "ocasional2", "78901234", "Uruguay", false));
        }
    }
}


