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
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol").Equals("Administrador"))
                {
                    try
                    {
                        IEnumerable<Cliente> clientes = miSistema.MostrarClientes();

                        return View(clientes);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Mensaje = ex.Message;
                    }
                }
            }

            return RedirectToAction("Login", "Home");
        }

        public IActionResult MostrarPerfil()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol").Equals("Cliente"))
                {
                    try
                    {
                        string mail = HttpContext.Session.GetString("mail");
                        Cliente cliente = miSistema.BuscarCliente(mail);

                        return View(cliente);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Mensaje = ex.Message;
                    }
                }
            }
            
            return RedirectToAction("Login", "Home");  
        }

        public IActionResult EditarPuntos()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol").Equals("Administrador"))
                {
                    try
                    {
                        return View();
                    } 
                    catch (Exception ex)
                    {
                        ViewBag.Mensaje = ex.Message;
                    }
                }
            }
            return RedirectToAction("Login", "Home");
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
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol").Equals("Administrador"))
                { 
                    try
                    {
                        return View();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Mensaje = ex.Message;
                    }
                }
            }
            return RedirectToAction("Login", "Home");
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
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }

        [HttpPost]

        public IActionResult RegistrarCliOcasional (string correoElectronico, string contrasenia, string nombre, string documento, string nacionalidad)
        {
            try
            {
                Ocasional ocasional = new Ocasional(correoElectronico, contrasenia, nombre, documento, nacionalidad);
                miSistema.AltaUsuarioClienteOcasional(ocasional);
                HttpContext.Session.SetString("rol", miSistema.Login(correoElectronico, contrasenia));
                HttpContext.Session.SetString("mail", correoElectronico);
                TempData["Mensaje"] = "Registro exitoso";
                return RedirectToAction(nameof(MostrarPerfil));
                
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }

            return View();
        }
    }
}
