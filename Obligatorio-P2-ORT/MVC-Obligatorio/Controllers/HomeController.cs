using System.Diagnostics;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using MVC_Obligatorio.Models;

namespace MVC_Obligatorio.Controllers;

public class HomeController : Controller
{
    Sistema miSistema = Sistema.Instancia;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

}
