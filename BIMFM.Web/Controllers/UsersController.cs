using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using BIMFM.Authorization;
using BIMFM.Users;

namespace BIMFM.Web.Controllers
{
    //[AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : BIMFMControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _userAppService.GetUsers();
            return View(output);
        }
    }
}