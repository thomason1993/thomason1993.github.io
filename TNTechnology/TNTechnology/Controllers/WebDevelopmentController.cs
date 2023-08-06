using Microsoft.AspNetCore.Mvc;

namespace TNTechnology.Controllers
{
    [Route("/web-development")]
    public class WebDevelopmentController : Controller
    {
        private readonly ILogger<WebDevelopmentController> _logger;

        public WebDevelopmentController(ILogger<WebDevelopmentController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("WebDevelopmentController");
            return View();
        }
    }
}
