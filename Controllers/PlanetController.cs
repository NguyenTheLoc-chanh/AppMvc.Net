using AppMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMvc.Net.Controllers;

    public class PlanetController : Controller
    {
        private readonly PlanetService _planetService;

        public PlanetController(PlanetService planetService)
        {
            _planetService = planetService;
        }

        public IActionResult Index()
        {
            return View();
        }
        // route Action
        [BindProperty(SupportsGet = true, Name = "action")]
        public string Name { get; set;}
        public IActionResult Mercury()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
    }
