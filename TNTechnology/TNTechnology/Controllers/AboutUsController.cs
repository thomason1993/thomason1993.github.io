using Microsoft.AspNetCore.Mvc;
using TNTechnology.Controllers.Base;

namespace TNTechnology.Controllers
{
    [Route("/about-us")]
    public class AboutUsController : BaseWebController
    {
        private readonly ILogger<AboutUsController> _logger;

        public AboutUsController(ILogger<AboutUsController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("About us");
            return View();
        }
    }
}
