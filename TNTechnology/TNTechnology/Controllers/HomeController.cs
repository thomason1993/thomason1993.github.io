using Microsoft.AspNetCore.Mvc;
using TNTechnology.Controllers.Base;

namespace TNTechnology.Controllers
{
    [Route("/")]
    public class HomeController : BaseWebController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Home page");
            return View();
        }
    }
}
