using Microsoft.AspNetCore.Mvc;

namespace MVC_Obligatorio.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
