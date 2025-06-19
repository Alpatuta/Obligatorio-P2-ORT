using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Obligatorio.Controllers
{
    public class PasajeController : Controller
    {
        private Sistema miSistema = Sistema.Instancia;
        public IActionResult Index()
        {
            return View(miSistema.Pasajes);
        }
    }
}
