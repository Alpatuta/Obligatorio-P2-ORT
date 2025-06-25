using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Obligatorio.Controllers
{
    public class PasajeController : Controller
    {
        private Sistema miSistema = Sistema.Instancia;

        public IActionResult VerPasaje()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol").Equals("Administrador"))
                {
                    try
                    {
                        IEnumerable<Pasaje> pasajes = miSistema.PasajesEntreFechas(DateTime.MinValue, DateTime.MaxValue);

                        return View(pasajes);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Mensaje = ex.Message;
                    }

                }
                if (HttpContext.Session.GetString("rol").Equals("Cliente"))
                {
                    return RedirectToAction("MostrarPerfil", "Usuario");
                }

            }

            return RedirectToAction("Login", "Home");
        }

        public IActionResult PasajesComprados()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol").Equals("Cliente"))
                {
                    try
                    {
                        Cliente cliente = null;
                        cliente = miSistema.BuscarCliente(HttpContext.Session.GetString("mail"));
                        if (cliente != null)
                        {
                            IEnumerable<Pasaje> pasajes = miSistema.BuscarPasajesPorCliente(cliente.Mail);

                            if (pasajes != null && pasajes.Count() > 0)
                            {
                                return View(pasajes);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        ViewBag.Mensaje = e.Message;
                    }
                }
            }
            return RedirectToAction("Login", "Home");
        }
    }
}
