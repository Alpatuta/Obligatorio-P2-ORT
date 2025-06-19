using Microsoft.AspNetCore.Mvc;

namespace MVC_Obligatorio.Controllers
{
    public class VueloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
