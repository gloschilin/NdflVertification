using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NdflVertification.Web.Api.Controllers
{
    public class EsssController : Controller
    {
        [HttpGet]
        [Route("~/reports/esss/upload")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("~/reports/{actionUserId}/esss")]
        public ActionResult Load(int actionUserId, HttpPostedFileBase file)
        {
            if (!Request.IsAjaxRequest())
            {
                throw new HttpException(404, "");
            }

            return Json("");
        }
    }
}