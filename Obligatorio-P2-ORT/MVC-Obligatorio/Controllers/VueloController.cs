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
            List<Vuelo> vuelos = miSistema.MostrarVuelos();
            return View(vuelos);  
        }

        public IActionResult ComprarPasaje()
        {
            return View();
        }

        [HttpPost]

        public IActionResult ComprarPasaje(string nroVuelo, DateTime fecha, string mail, Equipaje equipaje)
        {
            try
            {
                Vuelo vuelo = miSistema.BuscarVuelo(nroVuelo);
                Cliente pasajero = miSistema.BuscarCliente(mail);
                Pasaje pasaje = new Pasaje(vuelo, fecha, pasajero, equipaje);
                miSistema.AltaPasajes(pasaje);
                return RedirectToAction(nameof(MostrarVuelos));
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }
    }
}
