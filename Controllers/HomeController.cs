using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimerProyecto.Models;

namespace PrimerProyecto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private static Juego juego = new Juego();

        public IActionResult Index()
        {
            if (juego.DevolverListaUsuarios() == null || juego.DevolverListaUsuarios().Count == 0)
            {
                juego.LlenarListaPalabras();
            }
            ViewBag.Jugadores = juego.DevolverListaUsuarios();

            return View();
        }

        [HttpPost]
        public IActionResult Comenzar(string username, int dificultad)
        {
            HttpContext.Session.SetString("usuario", username);
            juego.LlenarListaPalabras();
            juego.InicializarJuego(username, dificultad);
            ViewBag.username = username;
            ViewBag.palabra = juego.CargarPalabra(dificultad);
            return View("Juego");
        }

        public IActionResult FinJuego(int intentos)
        {
            string nombreUsuario = HttpContext.Session.GetString("usuario");
            juego.FinJuego(intentos, nombreUsuario);
            return RedirectToAction("Index");
        }
    }
}
