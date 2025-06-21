using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace MVC_Obligatorio.Controllers
{
    public class UsuarioController : Controller
    {
        private Sistema miSistema = Sistema.Instancia;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MostrarClientes()
        {
            List<Cliente> clientes = miSistema.MostrarClientes();

            return View(clientes);
        }

        public IActionResult EditarPuntos()
        {
            return View();
        }

        [HttpPost]
        
        public IActionResult EditarPuntos(string mail, int puntos)
        {
            try
            {
                miSistema.EditarPuntos (mail, puntos);

                return RedirectToAction(nameof(MostrarClientes));
            }   catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }

        public IActionResult EditarElegible()
        {
            return View();
        }

        [HttpPost]

        public IActionResult EditarElegible(string mail, bool esElegible)
        {
            try
            {
                miSistema.EditarElegible(mail, esElegible);

                return RedirectToAction(nameof(MostrarClientes));
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }

        public IActionResult RegistrarCliOcasional ()
        {
            return View();
        }

        [HttpPost]

        public IActionResult RegistrarCliOcasional (string correoElectronico, string contrasenia, string nombre, string documento, string nacionalidad)
        {
            try
            {
                Ocasional ocasional = new Ocasional(correoElectronico, contrasenia, nombre, documento, nacionalidad);
                miSistema.AltaUsuarioClienteOcasional(ocasional);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }

            return View();
        }
    }
}
