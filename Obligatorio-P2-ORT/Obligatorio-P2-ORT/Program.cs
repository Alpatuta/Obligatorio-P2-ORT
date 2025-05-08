using Dominio;
namespace Obligatorio_P2_ORT
{
    public class Program
    {
        private static Sistema s = new Sistema();
        static void Main(string[] args)
        {
            try
            {
                s.PrecargaGeneral();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            int opcion = -1;
            while (opcion != 0) 
            {
                Menu();
                Console.WriteLine("Ingrese una opcion de menu");
                int.TryParse(Console.ReadLine(), out opcion);
                SeleccionarOpcion(opcion);
            }
            Console.ReadKey();
        }

        static void Menu()
        {
            Console.WriteLine(" ----------------");
            Console.WriteLine("| MENÚ PRINCIPAL |");
            Console.WriteLine(" ----------------");

            Console.WriteLine("1- Mostrar clientes");
            Console.WriteLine("2- Listado aeropuertos dado un codigo");
            Console.WriteLine("3- Alta cliente ocasional");
            Console.WriteLine("4- Listado pasajes dado dos fechas");
            Console.WriteLine("0- Salir");
            Console.WriteLine("");
        }

        static void SeleccionarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    MostrarClientes();
                    break;
                case 2:
                    ListadoVuelos();
                    break;
                case 3:
                    AltaClienteOcasional();
                    break;
                case 4:
                    ListadoPasajes();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }

        static void CrearCliente ()
        {
            Console.WriteLine("");
            Console.WriteLine("----------------Registro Cliente----------------");
            Console.WriteLine("");

            try
            {
                Console.WriteLine("Ingrese su nombre");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese su contraseña");
                string contrasenia = Console.ReadLine();

                Console.WriteLine("Ingrese su correo electronico");
                string correo = Console.ReadLine();

                Console.WriteLine("Ingrese su documento");
                string documento = Console.ReadLine();

                Console.WriteLine("Ingrese su nacionalidad");
                string nacionalidad = Console.ReadLine();

                Random random = new Random();

                int numeroRandom = random.Next(0, 1);
                bool elegible = false;

                if (numeroRandom == 1)
                {
                    elegible = true;
                }

                Ocasional ocasional = new Ocasional(correo, contrasenia, nombre, documento, nacionalidad, elegible);
                s.AltaUsuarioClienteOcasional(ocasional);

                Console.WriteLine("");
                Console.WriteLine("Cliente creado con exito");
                Console.WriteLine("");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                    
            }

           
        }

        static void MostrarClientes() 
        {
            Console.WriteLine("");
            Console.WriteLine("----------------Listado de Clientes----------------");
            Console.WriteLine("");

            Console.WriteLine(s.ClientesString());
        }

        static void ListadoVuelos()
        {
            Console.WriteLine("");
            Console.WriteLine("----------------Listado de Vuelos----------------");
            Console.WriteLine("");

            try
            {

                Console.WriteLine("Codigos disponibles: ");
                Console.WriteLine("JFK - LAX - LHR - CDG - FRA - NRT - SYD");
                Console.WriteLine("GRU - EZE - MEX - MAD - FCO - AMS - BCN");
                Console.WriteLine("YYZ - ATL - DXB - SIN - SCL - MVD");
                
                Console.WriteLine("");
                Console.WriteLine("Ingrese un codigo de aeropuerto");
                string codigo = Console.ReadLine().ToUpper();

                Console.WriteLine("");
                Console.WriteLine($"-Vuelos para {codigo.ToUpper()}-");
                Console.WriteLine("");

                Console.WriteLine(s.ListadoVuelosIATA(codigo));
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void AltaClienteOcasional()
        {
            CrearCliente();
        }

        static void ListadoPasajes() 
        {
            Console.WriteLine("");
            Console.WriteLine("----------------Listado de Pasajes----------------");
            Console.WriteLine("");

            Console.WriteLine("Ingrese la fecha de inicio");
            DateTime.TryParse(Console.ReadLine(), out DateTime fechaUno);
            Console.WriteLine("");

            Console.WriteLine("Ingrese la fecha final");
            DateTime.TryParse(Console.ReadLine(), out DateTime fechaDos);
            Console.WriteLine("");

            if (s.PasajesEntreFechas(fechaUno, fechaDos) == "")
            {
                Console.WriteLine("No hay pasajes entre esas fechas");
            } else
            {
                Console.WriteLine(s.PasajesEntreFechas(fechaUno, fechaDos));
            }
            
        }
    }
}
