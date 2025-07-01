using System.Diagnostics;
using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Obligatorio.Models;

namespace MVC_Obligatorio.Controllers;

public class HomeController : Controller
{
    Sistema miSistema = Sistema.Instancia;

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]

    public IActionResult Login(string mail, string contrasenia)
    {
        try
        {
            string rol = miSistema.Login(mail, contrasenia);
            if (!string.IsNullOrEmpty(rol))
            {
                HttpContext.Session.SetString("rol", rol);
                HttpContext.Session.SetString("mail", mail);
                if (rol.Equals("Administrador"))
                {
                    HttpContext.Session.GetString("mail");
                    return RedirectToAction("MostrarClientes", "Usuario");
                }

                if (rol.Equals("Cliente"))
                {
                    HttpContext.Session.GetString("mail");
                    return RedirectToAction("MostrarPerfil", "Usuario");
                }

            }
            else
            {
                ViewBag.Mensaje = "Crendenciales incorrectas";
            }
        }
        catch (Exception ex)
        {
            ViewBag.Mensaje = ex.Message;
        }

        return View();
    }

    public IActionResult Logout()
    {
        try
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        catch (Exception ex)
        {
            ViewBag.Mensaje = ex.Message;
        }
        return View();
    }
}
