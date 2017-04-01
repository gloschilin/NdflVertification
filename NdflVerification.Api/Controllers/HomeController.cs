
using System.Web;
using System.Web.Mvc;
using NdflVerification.ReportsContext.Domain.Services.Factories;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators;

namespace NdflVerification.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        private readonly IReportValidator<Файл> _esssValidator;
        private readonly IReportFactory<Файл> _reportFactory;

        public HomeController(IReportValidator<Файл> esssValidator,
            IReportFactory<Файл> reportFactory)
        {
            _esssValidator = esssValidator;
            _reportFactory = reportFactory;
        }

        private const string FileName = "esss.xml";

        [Route("~/reports/{actionUserId}/esss")]
        [HttpPost]
        public ActionResult UploadFile(int actionUserId, HttpPostedFileBase file)
        {
            return null;
            
        }

    }
}