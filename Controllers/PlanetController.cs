using AppMvc.Net.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace AppMvc.Net.Controllers
{
    [Route("he-mat-troi")]
    public class PlanetController : Controller
    {
        public readonly PlanetService _planetService;
        private readonly ILogger<PlanetController> _logger;
        public PlanetController(ILogger<PlanetController> logger, PlanetService planetService)
        {
            _logger = logger;
            _planetService = planetService;
        }
        public IActionResult Index()
        {
            return View();
        }

        // route: action
        [BindProperty(SupportsGet = true, Name = "action")]
        public string Name {get; set;} //action ~ PlanetModel
        
        [HttpGet("/saomoc.html")]
        public IActionResult Mercury()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        // [Route("[controller]-[action]-[area]")]
        [Route("hanhtinh/{id:int}", Order = 1, Name = "planetInfo")]
        public IActionResult PlanetInfo(int id)
        {
            var planet = _planetService.Where(p => p.Id == id).FirstOrDefault();
            return View("Detail", planet);
        }
    }
}