using System.Net;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;
using NdflVerification.ReportsContext.Domain.Services.Factories;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;

namespace NdflVertification.Web.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EsssController : Controller
    {
        private readonly IReportFactory<Файл> _essReportFactory;

        public EsssController(IReportFactory<Файл> essReportFactory)
        {
            _essReportFactory = essReportFactory;
        }

        [HttpGet]
        [Route("~/reports/{actionUserId}/esss/upload")]
        public ActionResult Index(int actionUserId)
        {
            ViewBag.ActionUserId = actionUserId;
            return View();
        }

        [HttpPost]
        [Route("~/reports/{actionUserId}/esss/upload")]
        public ActionResult Load(int actionUserId, HttpPostedFileBase file)
        {
            string path = $"~/Files/{actionUserId}";
            if (!Request.IsAjaxRequest())
            {
                throw new HttpException(404, "");
            }
            //check dir
            if (!System.IO.Directory.Exists(Server.MapPath(path)))
            {
                System.IO.Directory.CreateDirectory(Server.MapPath(path));
            }

            // сохраняем файл в папку Files в проекте
            file.SaveAs(Server.MapPath($"{path}/esss.file"));
            Файл result;
            if (!_essReportFactory.TryReadFromLocalFile(Server.MapPath($"{path}/esss.file"), out result))
            {
                throw new HttpException(409, "Incorrent format");
            }

            return Json(new { result = "ok" });
        }
    }
}