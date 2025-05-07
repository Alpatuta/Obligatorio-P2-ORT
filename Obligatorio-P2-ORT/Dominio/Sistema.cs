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

        public Usuario BuscarUsuario (string mail)
        {
            Usuario usuario = null;
            int i = 0;

            while (i < _usuarios.Count && usuario == null)
            {
                if (_usuarios[i].Mail == mail)
                {
                    usuario = _usuarios[i];
                }

                i++;
            }

            return usuario;
        }

        public Cliente BuscarCliente(string mail)
        {
            Cliente cliente = null;
            Usuario usuario = BuscarUsuario(mail);

            if (usuario != null && usuario is Cliente)
            {
                cliente = (Cliente)usuario;
            }

            return cliente;
        }

        // PRECARGAS

        public void PrecargaGeneral()
        {
            PrecargaUsuario();
            PrecargaAviones();
            PrecargaAeropuertos();
            PrecargaRutas();
            PrecargaVuelos();
            PrecargasPasajes();
        }
        private void PrecargaUsuario()
        {
            PrecargaUsuariosAdmin();
            PrecargaUsuarioClientePremium();
            PrecargaUsuarioClienteOcasional();
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
            AltaUsuarioClienteOcasional(new Ocasional("ocasional3@gmail.com", "1234", "ocasional3", "89012345", "Uruguay", true));
            AltaUsuarioClienteOcasional(new Ocasional("ocasional4@gmail.com", "1234", "ocasional4", "90123456", "Uruguay", false));
            AltaUsuarioClienteOcasional(new Ocasional("ocasional5@gmail.com", "1234", "ocasional5", "01234567", "Uruguay", false));
        }

        private void PrecargaAviones()
        {
            AltaAviones(new Avion("Boeing", "737MAX8", 178, 6570, 2600.50));
            AltaAviones(new Avion("Airbus", "A320neo", 180, 6300, 2500.75));
            AltaAviones(new Avion("Embraer", "E195-E2", 132, 4815, 2100.00));
            AltaAviones(new Avion("Bombardier", "CRJ900", 90, 2956, 1800.35));
        }

        private void PrecargaAeropuertos()
        {
            AltaAeropuertos(new Aeropuerto("JFK", "New York", 3500.00, 150.00));
            AltaAeropuertos(new Aeropuerto("LAX", "Los Angeles", 3400.00, 145.00));
            AltaAeropuertos(new Aeropuerto("LHR", "London", 4100.00, 180.00));
            AltaAeropuertos(new Aeropuerto("CDG", "Paris", 3900.00, 170.00));
            AltaAeropuertos(new Aeropuerto("FRA", "Frankfurt", 3700.00, 160.00));
            AltaAeropuertos(new Aeropuerto("NRT", "Tokyo", 4300.00, 190.00));
            AltaAeropuertos(new Aeropuerto("SYD", "Sydney", 3200.00, 140.00));
            AltaAeropuertos(new Aeropuerto("GRU", "São Paulo", 2800.00, 130.00));
            AltaAeropuertos(new Aeropuerto("EZE", "Buenos Aires", 2600.00, 120.00));
            AltaAeropuertos(new Aeropuerto("MEX", "Mexico City", 3000.00, 125.00));
            AltaAeropuertos(new Aeropuerto("MAD", "Madrid", 3300.00, 150.00));
            AltaAeropuertos(new Aeropuerto("FCO", "Rome", 3100.00, 145.00));
            AltaAeropuertos(new Aeropuerto("AMS", "Amsterdam", 3500.00, 160.00));
            AltaAeropuertos(new Aeropuerto("BCN", "Barcelona", 3200.00, 140.00));
            AltaAeropuertos(new Aeropuerto("YYZ", "Toronto", 3400.00, 155.00));
            AltaAeropuertos(new Aeropuerto("ATL", "Atlanta", 3600.00, 150.00));
            AltaAeropuertos(new Aeropuerto("DXB", "Dubai", 4500.00, 200.00));
            AltaAeropuertos(new Aeropuerto("SIN", "Singapore", 4300.00, 185.00));
            AltaAeropuertos(new Aeropuerto("SCL", "Santiago", 2700.00, 120.00));
            AltaAeropuertos(new Aeropuerto("MVD", "Montevideo", 2200.00, 110.00));
        }

        private void PrecargaRutas()
        {
            AltaRutas(new Ruta(BuscarAeropuerto("JFK"), BuscarAeropuerto("LAX"), 3983));
            AltaRutas(new Ruta(BuscarAeropuerto("JFK"), BuscarAeropuerto("CDG"), 5846));
            AltaRutas(new Ruta(BuscarAeropuerto("LAX"), BuscarAeropuerto("NRT"), 8785));
            AltaRutas(new Ruta(BuscarAeropuerto("LHR"), BuscarAeropuerto("DXB"), 5500));
            AltaRutas(new Ruta(BuscarAeropuerto("EZE"), BuscarAeropuerto("GRU"), 1670));
            AltaRutas(new Ruta(BuscarAeropuerto("SYD"), BuscarAeropuerto("SIN"), 6300));
            AltaRutas(new Ruta(BuscarAeropuerto("MEX"), BuscarAeropuerto("LAX"), 2500));
            AltaRutas(new Ruta(BuscarAeropuerto("ATL"), BuscarAeropuerto("YYZ"), 1190));
            AltaRutas(new Ruta(BuscarAeropuerto("MVD"), BuscarAeropuerto("GRU"), 1580));
            AltaRutas(new Ruta(BuscarAeropuerto("SCL"), BuscarAeropuerto("EZE"), 1130));
            AltaRutas(new Ruta(BuscarAeropuerto("CDG"), BuscarAeropuerto("FCO"), 1105));
            AltaRutas(new Ruta(BuscarAeropuerto("FCO"), BuscarAeropuerto("MAD"), 1360));
            AltaRutas(new Ruta(BuscarAeropuerto("BCN"), BuscarAeropuerto("AMS"), 1240));
            AltaRutas(new Ruta(BuscarAeropuerto("JFK"), BuscarAeropuerto("MAD"), 5760));
            AltaRutas(new Ruta(BuscarAeropuerto("JFK"), BuscarAeropuerto("YYZ"), 600));
            AltaRutas(new Ruta(BuscarAeropuerto("LHR"), BuscarAeropuerto("AMS"), 360));
            AltaRutas(new Ruta(BuscarAeropuerto("GRU"), BuscarAeropuerto("MEX"), 7450));
            AltaRutas(new Ruta(BuscarAeropuerto("MVD"), BuscarAeropuerto("EZE"), 205));
            AltaRutas(new Ruta(BuscarAeropuerto("MVD"), BuscarAeropuerto("SCL"), 1370));
            AltaRutas(new Ruta(BuscarAeropuerto("LAX"), BuscarAeropuerto("SYD"), 12050));
            AltaRutas(new Ruta(BuscarAeropuerto("NRT"), BuscarAeropuerto("SIN"), 5325));
            AltaRutas(new Ruta(BuscarAeropuerto("DXB"), BuscarAeropuerto("SIN"), 5840));
            AltaRutas(new Ruta(BuscarAeropuerto("CDG"), BuscarAeropuerto("SIN"), 10730));
            AltaRutas(new Ruta(BuscarAeropuerto("ATL"), BuscarAeropuerto("LAX"), 3110));
            AltaRutas(new Ruta(BuscarAeropuerto("AMS"), BuscarAeropuerto("FRA"), 370));
            AltaRutas(new Ruta(BuscarAeropuerto("BCN"), BuscarAeropuerto("CDG"), 850));
            AltaRutas(new Ruta(BuscarAeropuerto("MAD"), BuscarAeropuerto("EZE"), 10120));
            AltaRutas(new Ruta(BuscarAeropuerto("LHR"), BuscarAeropuerto("JFK"), 5540));
            AltaRutas(new Ruta(BuscarAeropuerto("FRA"), BuscarAeropuerto("DXB"), 4830));
            AltaRutas(new Ruta(BuscarAeropuerto("SIN"), BuscarAeropuerto("SYD"), 6300));
        }

        private void PrecargaVuelos()
        {
            AltaVuelos(new Vuelo("AR101", Frecuencia.Lunes, BuscarRuta(0), BuscarAvion(0)));
            AltaVuelos(new Vuelo("AR102", Frecuencia.Martes, BuscarRuta(1), BuscarAvion(1)));
            AltaVuelos(new Vuelo("AR103", Frecuencia.Miércoles, BuscarRuta(2), BuscarAvion(2)));
            AltaVuelos(new Vuelo("AR104", Frecuencia.Jueves, BuscarRuta(3), BuscarAvion(3)));
            AltaVuelos(new Vuelo("AR105", Frecuencia.Viernes, BuscarRuta(4), BuscarAvion(0)));
            AltaVuelos(new Vuelo("AR106", Frecuencia.Sábado, BuscarRuta(5), BuscarAvion(1)));
            AltaVuelos(new Vuelo("AR107", Frecuencia.Domingo, BuscarRuta(6), BuscarAvion(2)));
            AltaVuelos(new Vuelo("AR108", Frecuencia.Lunes, BuscarRuta(7), BuscarAvion(3)));
            AltaVuelos(new Vuelo("AR109", Frecuencia.Martes, BuscarRuta(8), BuscarAvion(0)));
            AltaVuelos(new Vuelo("AR110", Frecuencia.Miércoles, BuscarRuta(9), BuscarAvion(1)));
            AltaVuelos(new Vuelo("AR111", Frecuencia.Jueves, BuscarRuta(10), BuscarAvion(2)));
            AltaVuelos(new Vuelo("AR112", Frecuencia.Viernes, BuscarRuta(11), BuscarAvion(3)));
            AltaVuelos(new Vuelo("AR113", Frecuencia.Sábado, BuscarRuta(12), BuscarAvion(0)));
            AltaVuelos(new Vuelo("AR114", Frecuencia.Domingo, BuscarRuta(13), BuscarAvion(1)));
            AltaVuelos(new Vuelo("AR115", Frecuencia.Lunes, BuscarRuta(14), BuscarAvion(2)));
            AltaVuelos(new Vuelo("AR116", Frecuencia.Martes, BuscarRuta(15), BuscarAvion(3)));
            AltaVuelos(new Vuelo("AR117", Frecuencia.Miércoles, BuscarRuta(16), BuscarAvion(0)));
            AltaVuelos(new Vuelo("AR118", Frecuencia.Jueves, BuscarRuta(17), BuscarAvion(1)));
            AltaVuelos(new Vuelo("AR119", Frecuencia.Viernes, BuscarRuta(18), BuscarAvion(2)));
            AltaVuelos(new Vuelo("AR120", Frecuencia.Sábado, BuscarRuta(19), BuscarAvion(3)));
            AltaVuelos(new Vuelo("AR121", Frecuencia.Domingo, BuscarRuta(20), BuscarAvion(0)));
            AltaVuelos(new Vuelo("AR122", Frecuencia.Lunes, BuscarRuta(21), BuscarAvion(1)));
            AltaVuelos(new Vuelo("AR123", Frecuencia.Martes, BuscarRuta(22), BuscarAvion(2)));
            AltaVuelos(new Vuelo("AR124", Frecuencia.Miércoles, BuscarRuta(23), BuscarAvion(3)));
            AltaVuelos(new Vuelo("AR125", Frecuencia.Jueves, BuscarRuta(24), BuscarAvion(0)));
            AltaVuelos(new Vuelo("AR126", Frecuencia.Viernes, BuscarRuta(25), BuscarAvion(1)));
            AltaVuelos(new Vuelo("AR127", Frecuencia.Sábado, BuscarRuta(26), BuscarAvion(2)));
            AltaVuelos(new Vuelo("AR128", Frecuencia.Domingo, BuscarRuta(27), BuscarAvion(3)));
            AltaVuelos(new Vuelo("AR129", Frecuencia.Lunes, BuscarRuta(28), BuscarAvion(0)));
            AltaVuelos(new Vuelo("AR130", Frecuencia.Martes, BuscarRuta(29), BuscarAvion(1)));
        }

        private void PrecargasPasajes()
        {
            AltaPasajes(new Pasaje(BuscarVuelo("AR101"), new DateTime(2025, 06, 01), BuscarCliente("ocasional1@gmail.com"), Equipaje.Cabina));
            AltaPasajes(new Pasaje(BuscarVuelo("AR102"), new DateTime(2025, 06, 02), BuscarCliente("ocasional2@gmail.com"), Equipaje.Light));
            AltaPasajes(new Pasaje(BuscarVuelo("AR103"), new DateTime(2025, 06, 03), BuscarCliente("ocasional3@gmail.com"), Equipaje.Bodega));
            AltaPasajes(new Pasaje(BuscarVuelo("AR104"), new DateTime(2025, 06, 04), BuscarCliente("ocasional4@gmail.com"), Equipaje.Cabina));
            AltaPasajes(new Pasaje(BuscarVuelo("AR105"), new DateTime(2025, 06, 05), BuscarCliente("ocasional5@gmail.com"), Equipaje.Bodega));
            AltaPasajes(new Pasaje(BuscarVuelo("AR106"), new DateTime(2025, 06, 06), BuscarCliente("ocasional5@gmail.com"), Equipaje.Light));
            AltaPasajes(new Pasaje(BuscarVuelo("AR107"), new DateTime(2025, 06, 07), BuscarCliente("ocasional5@gmail.com"), Equipaje.Cabina));
            AltaPasajes(new Pasaje(BuscarVuelo("AR108"), new DateTime(2025, 06, 08), BuscarCliente("ocasional3@gmail.com"), Equipaje.Bodega));
            AltaPasajes(new Pasaje(BuscarVuelo("AR109"), new DateTime(2025, 06, 09), BuscarCliente("ocasional4@gmail.com"), Equipaje.Cabina));
            AltaPasajes(new Pasaje(BuscarVuelo("AR110"), new DateTime(2025, 06, 10), BuscarCliente("ocasional3@gmail.com"), Equipaje.Light));
            AltaPasajes(new Pasaje(BuscarVuelo("AR111"), new DateTime(2025, 06, 11), BuscarCliente("ocasional4@gmail.com"), Equipaje.Bodega));
            AltaPasajes(new Pasaje(BuscarVuelo("AR112"), new DateTime(2025, 06, 12), BuscarCliente("ocasional4@gmail.com"), Equipaje.Light));
            AltaPasajes(new Pasaje(BuscarVuelo("AR113"), new DateTime(2025, 06, 13), BuscarCliente("ocasional5@gmail.com"), Equipaje.Cabina));
            AltaPasajes(new Pasaje(BuscarVuelo("AR114"), new DateTime(2025, 06, 14), BuscarCliente("ocasional2@gmail.com"), Equipaje.Bodega));
            AltaPasajes(new Pasaje(BuscarVuelo("AR115"), new DateTime(2025, 06, 15), BuscarCliente("ocasional5@gmail.com"), Equipaje.Light));
            AltaPasajes(new Pasaje(BuscarVuelo("AR116"), new DateTime(2025, 06, 16), BuscarCliente("ocasional4@gmail.com"), Equipaje.Cabina));
            AltaPasajes(new Pasaje(BuscarVuelo("AR117"), new DateTime(2025, 06, 17), BuscarCliente("ocasional1@gmail.com"), Equipaje.Bodega));
            AltaPasajes(new Pasaje(BuscarVuelo("AR118"), new DateTime(2025, 06, 18), BuscarCliente("ocasional4@gmail.com"), Equipaje.Cabina));
            AltaPasajes(new Pasaje(BuscarVuelo("AR119"), new DateTime(2025, 06, 19), BuscarCliente("ocasional4@gmail.com"), Equipaje.Light));
            AltaPasajes(new Pasaje(BuscarVuelo("AR120"), new DateTime(2025, 06, 20), BuscarCliente("ocasional2@gmail.com"), Equipaje.Bodega));
            AltaPasajes(new Pasaje(BuscarVuelo("AR121"), new DateTime(2025, 06, 21), BuscarCliente("ocasional2@gmail.com"), Equipaje.Cabina));
            AltaPasajes(new Pasaje(BuscarVuelo("AR122"), new DateTime(2025, 06, 22), BuscarCliente("ocasional1@gmail.com"), Equipaje.Light));
            AltaPasajes(new Pasaje(BuscarVuelo("AR123"), new DateTime(2025, 06, 23), BuscarCliente("ocasional1@gmail.com"), Equipaje.Bodega));
            AltaPasajes(new Pasaje(BuscarVuelo("AR124"), new DateTime(2025, 06, 24), BuscarCliente("ocasional3@gmail.com"), Equipaje.Light));
            AltaPasajes(new Pasaje(BuscarVuelo("AR125"), new DateTime(2025, 06, 25), BuscarCliente("ocasional5@gmail.com"), Equipaje.Cabina));

        }


        //Mostrar clientes
        public string ClientesString()
        {
            string datosCliente = "";

            foreach(Usuario usu in _usuarios)
            {
                if(usu is Cliente)
                {
                    datosCliente += usu.ToString();
                }
            }

            return datosCliente;
        }

        //Mostrar vuelos determinados
        public string ListadoVuelosIATA(string codigo)
        {
            string vuelosIATA = "";

            if(codigo.Length == 3 && BuscarAeropuerto(codigo) != null)
            {
                foreach (Vuelo vuelo in _vuelos)
                {
                    if (vuelo.PerteneceRuta(codigo))
                    {
                        vuelosIATA += vuelo.ToString();
                    }
                }
            }
            else
            {
                throw new Exception("Codigo IATA invalido");
            }

            return vuelosIATA;
        }
    }
}


