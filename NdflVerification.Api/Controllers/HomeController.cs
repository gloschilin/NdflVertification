using System.Web;
using System.Web.Mvc;

namespace NdflVerification.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [Route("~/reports/esss")]
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            return null;
        }
    }
}