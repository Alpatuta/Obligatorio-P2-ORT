using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace MVC_Obligatorio.Controllers
{
    public class UsuarioController : Controller
    {
        private Sistema miSistema = Sistema.Instancia;
        public IActionResult Index()
        {
            
            
            return View(miSistema.Usuarios);
        }


    }
}
