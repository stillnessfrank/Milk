using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BIMFM.Users;
using BIMFM.Web.Models.Users;

namespace BIMFM.Web.Controllers
{
    public class UserMgrController : BIMFMControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserMgrController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        // GET: UserMgr
        public async Task<ActionResult> Index()
        {
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new UserListViewModel
            {
                Roles = roles
            };
            return View(model);
        }

        public async Task<ActionResult> AddUser()
        {
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new UserListViewModel
            {
                Roles = roles
            };
            return View(model);
        }
    }
}