using Microsoft.AspNetCore.Mvc;
using TNTechnology.Business.Authorization;
using TNTechnology.Business.Models.Admin;

namespace TNTechnology.Controllers.Base
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BaseWebController : Controller
    {
        public ApplicationAdmin CurrentAdmin
        {
            get
            {
                var model = HttpContext.Items["Admin"] as AdminModel;

                if (model == null)
                {
                    return new ApplicationAdmin();
                }

                return new ApplicationAdmin
                {
                    Id = model.Id,
                    Email = model.Email,
                    FullName = model.FullName,
                    Avatar = model.Avatar,
                    Roles = model.Roles,
                };
            }
        }
    }
}
