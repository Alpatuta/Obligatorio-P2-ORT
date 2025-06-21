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
            try
            {
                List<Vuelo> vuelos = miSistema.MostrarVuelos();
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }
    }
}
