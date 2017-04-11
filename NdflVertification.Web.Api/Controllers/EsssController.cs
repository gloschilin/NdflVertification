using System.Net;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;
using NdflVerification.ReportsContext.Domain.Services.Factories;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators;

namespace NdflVertification.Web.Api.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EsssController : Controller
    {
        private readonly IReportFactory<Файл> _essReportFactory;
        private readonly IReportValidator<Файл> _validator;

        public EsssController(IReportFactory<Файл> essReportFactory, IReportValidator<Файл> validator)
        {
            _essReportFactory = essReportFactory;
            _validator = validator;
        }

        

        [HttpGet]
        [Route("~/reports/{actionUserId}/esss/upload")]
        public ActionResult Index(int actionUserId)
        {
            ViewBag.ActionUserId = actionUserId;
            return View();
        }

        //[AcceptVerbs("OPTIONS")]
        //public HttpResponseMessage Options()
        //{
        //    var resp = new HttpResponseMessage(HttpStatusCode.OK);
        //    resp.Headers.Add("Access-Control-Allow-Origin", "*");
        //    resp.Headers.Add("Access-Control-Allow-Methods", "GET,DELETE");

        //    return resp;
        //}
        

        [HttpOptions]
        [Route("~/reports/{actionUserId}/esss/upload")]
        public ActionResult LoadOptions(int actionUserId, HttpPostedFileBase file)
        {
            return Json("ok");
        }

        [HttpPost]
        [Route("~/reports/{actionUserId}/esss/upload")]
        public ActionResult Load(int actionUserId, HttpPostedFileBase file)
        {
            string path = $"~/Files/{actionUserId}";
            
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
                System.IO.File.Delete(Server.MapPath($"{path}/esss.file"));
                throw new HttpException(400, "Incorrent format");
            }

            //try valid file
            if (!_validator.TryValidate(result))
            {
                System.IO.File.Delete(Server.MapPath($"{path}/esss.file"));
                throw new HttpException(400, "Incorrent format");
            }

            return Json(new { result = "ok" });
        }
    }
}