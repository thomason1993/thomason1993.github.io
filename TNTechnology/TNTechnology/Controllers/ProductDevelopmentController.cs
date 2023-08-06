using Microsoft.AspNetCore.Mvc;
using TNTechnology.Controllers.Base;

namespace TNTechnology.Controllers
{
    [Route("/product-development")]
    public class ProductDevelopmentController : BaseWebController
    {
        private readonly ILogger<ProductDevelopmentController> _logger;

        public ProductDevelopmentController(ILogger<ProductDevelopmentController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Product development page");
            return View();
        }
    }
}
