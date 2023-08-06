using Microsoft.AspNetCore.Mvc;
using TNTechnology.Controllers.Base;

namespace TNTechnology.Controllers
{
    [Route("/ui-ux-design")]
    public class UIUXDesignController : BaseWebController
    {
        private readonly ILogger<UIUXDesignController> _logger;

        public UIUXDesignController(ILogger<UIUXDesignController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("ui-ux-design page");
            return View();
        }
    }
}
