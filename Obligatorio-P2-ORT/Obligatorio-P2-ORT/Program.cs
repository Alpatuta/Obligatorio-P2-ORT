using Dominio;
namespace Obligatorio_P2_ORT
{
    public class Program
    {
        private static Sistema s = new Sistema();
        static void Main(string[] args)
        {
            
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
    }
}
