using Microsoft.AspNetCore.Mvc;
using TNTechnology.Controllers.Base;

namespace TNTechnology.Controllers
{
    [Route("/software-testing-services")]
    public class SoftwareTestingServicesController : BaseWebController
    {
        private readonly ILogger<SoftwareTestingServicesController> _logger;

        public SoftwareTestingServicesController(ILogger<SoftwareTestingServicesController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Software Testing Services page");
            return View();
        }
    }
}
