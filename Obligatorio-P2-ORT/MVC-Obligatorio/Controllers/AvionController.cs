using Microsoft.AspNetCore.Mvc;

namespace MVC_Obligatorio.Controllers
{
    public class AvionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
