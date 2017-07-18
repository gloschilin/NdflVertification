using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using NdflVerification.ReportsContext.Domain;
using NdflVerification.ReportsContext.Domain.Services.Factories;
using NdflVerification.ReportsContext.Domain.Services.Validators;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;
using NdflVertification.Web.Api.Utils;

namespace NdflVertification.Web.Api.Controllers
{
    public class ReportsApiController : ApiController
    {
        private readonly IEnumerable<IReportFactory<NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss.Файл>> _esssFactories;
        private readonly IReportFactory<NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Six.Файл> _ndfl6Factory;
        private readonly IEnumerable<IFileUploader> _fileUploaders;
        private readonly IReportValidator<Reports> _reportValidator;

        public ReportsApiController(IReportValidator<Reports> reportValidator,
            IEnumerable<IReportFactory<NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss.Файл>> esssFactories, 
            IReportFactory<NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Six.Файл> ndfl6Factory,
            IEnumerable<IFileUploader> fileUploaders)
        {
            _reportValidator = reportValidator;
            _esssFactories = esssFactories;
            _ndfl6Factory = ndfl6Factory;
            _fileUploaders = fileUploaders;
        }

        [HttpGet]
        [Route("~/reports/{actionUserId}")]
        public IHttpActionResult Validate(int actionUserId)
        {
            var reports = new Reports();

            var ndflUploader = _fileUploaders.First(e => e.Type == ReportType.SixNdfl);
            var esssUploader = _fileUploaders.First(e => e.Type == ReportType.Esss1);

            if (ndflUploader.Exists(actionUserId))
            {
                reports.Ndfl6 = _ndfl6Factory.ReadFromLocalFile(ndflUploader.Path(actionUserId));
            }

            if (esssUploader.Exists(actionUserId))
            {
                var essFactory = _esssFactories.First(e => e.ReportType == esssUploader.Type);
                var path = esssUploader.Path(actionUserId);
                reports.Esss = essFactory.ReadFromLocalFile(path);
            }

            _reportValidator.Validate(reports);
            var result = HttpContext.Current.Items["WebValidationResultHandler"] as List<WebValidationInfo>
                ?? new List<WebValidationInfo>();

            return Ok(result.Where(e => e.Status == ValidationResultType.Error));
        }

        [HttpGet]
        [Route("~/reports/{actionUserId}/info")]
        public ReportsInfo GetInfo(int actionUserId)
        {
            var info = new ReportsInfo();

            foreach (var fileUploader in _fileUploaders)
            {
                var exists = fileUploader.Exists(actionUserId);

                switch (fileUploader.Type)
                {
                    case ReportType.SixNdfl:
                        info.Ndfl6 = exists;
                        break;
                    case ReportType.Esss1:
                        info.Esss1 = exists;
                        break;
                    case ReportType.Esss2:
                        info.Esss1 = exists;
                        break;
                    case ReportType.Esss3:
                        info.Esss1 = exists;
                        break;
                    case ReportType.Esss4:
                        info.Esss1 = exists;
                        break;
                    default:
                        throw new HttpException("");
                }
            }

            return info;
        }

        [HttpDelete]
        [Route("~/reports/{actionUserId}/esss1/delete")]
        public void DeleteEsss1(int actionUserId)
        {
            var uploader = _fileUploaders.First(e => e.Type == ReportType.Esss1);
            uploader.Delete(actionUserId);
        }

        [HttpDelete]
        [Route("~/reports/{actionUserId}/esss2/delete")]
        public void DeleteEsss2(int actionUserId)
        {
            var uploader = _fileUploaders.First(e => e.Type == ReportType.Esss2);
            uploader.Delete(actionUserId);
        }

        [HttpDelete]
        [Route("~/reports/{actionUserId}/esss3/delete")]
        public void DeleteEsss3(int actionUserId)
        {
            var uploader = _fileUploaders.First(e => e.Type == ReportType.Esss3);
            uploader.Delete(actionUserId);
        }

        [HttpDelete]
        [Route("~/reports/{actionUserId}/esss4/delete")]
        public void DeleteEsss4(int actionUserId)
        {
            var uploader = _fileUploaders.First(e => e.Type == ReportType.Esss4);
            uploader.Delete(actionUserId);
        }

        [HttpDelete]
        [Route("~/reports/{actionUserId}/ndfl-6/delete")]
        public void DeleteNdfl6(int actionUserId)
        {
            var uploader = _fileUploaders.First(e => e.Type == ReportType.SixNdfl);
            uploader.Delete(actionUserId);
        }

        [HttpOptions]
        [Route("~/reports/{actionUserId}/esss/delete")]
        public IHttpActionResult DeleteEsssOptions(int actionUserId)
        {
            return Ok();
        }

        [HttpOptions]
        [Route("~/reports/{actionUserId}/ndfl-6/delete")]
        public IHttpActionResult DeleteNdfl6Options(int actionUserId)
        {
            return Ok();
        }

        [HttpGet]
        [Route("~/reports/{actionUserId}/delete")]
        public void Delete(int actionUserId)
        {
            foreach (var fileUploader in _fileUploaders.Where(fileUploader => fileUploader.Exists(actionUserId)))
            {
                fileUploader.Delete(actionUserId);
            }
        }

        [HttpOptions]
        [Route("~/reports/{actionUserId}/delete")]
        public IHttpActionResult DeleteOptions(int actionUserId)
        {
            //HttpContext.Current.Response.Headers.Clear();
            //HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Header;", "Origin, X-Requested-With, Content-Type, Accept, Authorization");
            //HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS, PUT, DELETE");
            //HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Ok();
        }
    }
}
