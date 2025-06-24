using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Obligatorio.Controllers
{
    public class PasajeController : Controller
    {
        private Sistema miSistema = Sistema.Instancia;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VerPasaje()
        {
            try
            {
                IEnumerable<Pasaje> pasajes = miSistema.PasajesEntreFechas(DateTime.MinValue, DateTime.MaxValue);

                return View(pasajes);
            }catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }

            return View();
        }

        public IActionResult PasajesComprados()
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

            

            return View();
        }
    }
}
