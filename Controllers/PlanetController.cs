using System.Text.Json.Serialization;
using AppMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMvc.Net.Controllers;

    [Route("he-mat-troi")]
    public class PlanetController : Controller
    {
        private readonly PlanetService _planetService;

        public PlanetController(PlanetService planetService)
        {
            _planetService = planetService;
        }

        [Route("danh-sach-cac-hanh-tinh.html")]
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
        public IActionResult Mars()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        
        // Controller, action, area => [controller] [action] [area]
        [Route("sao/[action]", Order = 1)]   // => sao/Saturn Oder là sự ưu tiên Route
        [Route("sao/[controller]/[action]", Order = 1)]  //=> sao/Planet/Saturn
        [Route("[controller]-[action].html", Order = 1)] //=> Planet-Saturn.html
        public IActionResult Saturn()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        [Route("hanhtinh/{id:int}")]
        public IActionResult PlanetInfo(int id)
        {
            var planet = _planetService.Where(p => p.Id  == id).FirstOrDefault();
            return View("Detail", planet);
        }
    }
