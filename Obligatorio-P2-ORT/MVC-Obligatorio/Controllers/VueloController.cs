using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Obligatorio.Controllers
{
    public class VueloController : Controller
    {
        Sistema miSistema = Sistema.Instancia;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MostrarVuelos()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol").Equals("Cliente"))
                {
                    try
                    {
                        IEnumerable<Vuelo> vuelos = miSistema.MostrarVuelos();
                        return View(vuelos);

                    }
                    catch (Exception ex)
                    {
                        ViewBag.Mensaje = ex.Message;
                    }
                }
            }
            return RedirectToAction("Login", "Home");
        }

        public IActionResult ComprarPasaje()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol").Equals("Cliente"))
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

        public IActionResult ComprarPasaje(string nroVuelo, DateTime fecha, Equipaje equipaje)
        {
            try
            {
                string mail = HttpContext.Session.GetString("mail");
                Vuelo vuelo = miSistema.BuscarVuelo(nroVuelo);
                Cliente pasajero = miSistema.BuscarCliente(mail);
                Pasaje pasaje = new Pasaje(vuelo, fecha, pasajero, equipaje);
                miSistema.AltaPasajes(pasaje);
                TempData["Mensaje"] = "Compra realizada con exito";
                return RedirectToAction("PasajesComprados" ,"Pasaje");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }

        public IActionResult BuscarVuelo()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol").Equals("Cliente"))
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

        public IActionResult BuscarVuelo(string codIata)
        {
            try
            {
                IEnumerable<Vuelo> vuelos = miSistema.ListadoVuelosIATA(codIata);
                return View(vuelos);
            }catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }

            return View();
        }
    }
}
