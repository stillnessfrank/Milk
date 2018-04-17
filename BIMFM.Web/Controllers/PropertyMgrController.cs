using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BIMFM.PropertyApp;
using BIMFM.PropertyApp.Dto;
using BIMFM.Users;

namespace BIMFM.Web.Controllers
{
    public class PropertyMgrController : BIMFMControllerBase
    {

        private readonly IPropertyAppServices _propertyAppService;

        public PropertyMgrController(IPropertyAppServices propertyAppService)
        {
            _propertyAppService = propertyAppService;
        }
        // GET: PropertyMgr
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProperty()
        {
            return View();
        }

        public ActionResult RoomMgr()
        {
            return View();
        }

        public ActionResult AddRoom()
        {
            string propertyId = Request.QueryString["propertyId"];
            ViewBag.propertyId = propertyId;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Upload()
        {
            string id = Request["id"];

            var files = Request.Files
                .Cast<string>()
                .Select(k => Request.Files[k])
                .ToArray();

            foreach (var file in files)
            {
                string filePath = SaveFileToDisk(file);
                PropertyDto input = new PropertyDto();
                input.Id = Convert.ToInt32(id);
                var prop = await _propertyAppService.GetPropertyById(input);
                prop.CoverPhoto = filePath;
                await _propertyAppService.UpdateProperty(prop);
            }
                
            var names = files.Select(f => f.FileName);
            return Json("ok");
        }

        private string SaveFileToDisk(HttpPostedFileBase file)
        {
            var folder = Server.MapPath("/FileUpload/");
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName); 
            var targetPath = Path.Combine(folder, fileName);
            file.SaveAs(targetPath);
            return "/FileUpload/" + fileName;
        }

    }
}