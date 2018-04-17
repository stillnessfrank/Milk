using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using BIMFM.Entities;

namespace BIMFM.Web.Controllers
{

    [AbpMvcAuthorize]
    public class HomeController : BIMFMControllerBase
    {

        public ActionResult Index()
        {
            return View();
        }

    }
}