using System.Web.Mvc;

namespace BIMFM.Web.Controllers
{
    public class AboutController : BIMFMControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}