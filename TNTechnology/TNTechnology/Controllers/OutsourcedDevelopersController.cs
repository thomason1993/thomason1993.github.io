using Microsoft.AspNetCore.Mvc;
using TNTechnology.Controllers.Base;

namespace TNTechnology.Controllers
{
    [Route("/outsourced-developers")]
    public class OutsourcedDevelopersController : BaseWebController
    {
        private readonly ILogger<OutsourcedDevelopersController> _logger;

        public OutsourcedDevelopersController(ILogger<OutsourcedDevelopersController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("OutsourcedDevelopersController");
            return View();
        }
    }
}
