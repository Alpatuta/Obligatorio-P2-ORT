using Dominio;
namespace Obligatorio_P2_ORT
{
    public class Program
    {
        private static Sistema s = new Sistema();
        static void Main(string[] args)
        {
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
            Console.WriteLine("1- Mostrar clientes");
            Console.WriteLine("2- Listado aeropuertos dado un codigo");
            Console.WriteLine("3- Alta cliente ocasional");
            Console.WriteLine("4- Listado pasajes dado dos fechas");
            Console.WriteLine("0- Salir");
        }

        static void SeleccionarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    MostrarClientes();
                    break;
                case 2:
                    ListadoAeropuertos();
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

           
        }

        static void MostrarClientes()
        {
            s.PrecargaGeneral();
        }

        static void ListadoAeropuertos()
        {
            Console.WriteLine("2");
        }

        static void AltaClienteOcasional()
        {
            Console.WriteLine("3");
        }

        static void ListadoPasajes() 
        {
            Console.WriteLine("4");
        }
    }
}
