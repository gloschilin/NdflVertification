using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private readonly IReportFactory<NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss.Файл> _esssFactory;
        private readonly IReportFactory<NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Six.Файл> _ndfl6Factory;
        private readonly IEnumerable<IFileUploader> _fileUploaders;
        private readonly IReportValidator<Reports> _reportValidator;

        public ReportsApiController(IReportValidator<Reports> reportValidator, 
            IReportFactory<NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss.Файл> esssFactory, 
            IReportFactory<NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Six.Файл> ndfl6Factory,
            IEnumerable<IFileUploader> fileUploaders)
        {
            _reportValidator = reportValidator;
            _esssFactory = esssFactory;
            _ndfl6Factory = ndfl6Factory;
            _fileUploaders = fileUploaders;
        }

        [HttpGet]
        [Route("~/reports/{actionUserId}")]
        public IHttpActionResult Validate(int actionUserId)
        {
            var reports = new Reports();

            var ndflUploader = _fileUploaders.First(e => e.Type == ReportType.SixNdfl);
            var esssUploader = _fileUploaders.First(e => e.Type == ReportType.Esss);

            if (ndflUploader.Exists(actionUserId))
            {
                reports.Ndfl6 = _ndfl6Factory.ReadFromLocalFile(ndflUploader.Path(actionUserId));
            }

            if (esssUploader.Exists(actionUserId))
            {
                reports.Esss = _esssFactory.ReadFromLocalFile(esssUploader.Path(actionUserId));
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
                    case ReportType.Esss:
                        info.Esss = exists;
                        break;
                    default:
                        throw new HttpException("");
                }
            }

            return info;
        }

        [HttpDelete]
        [Route("~/reports/{actionUserId}/esss/delete")]
        public void DeleteEsss(int actionUserId)
        {
            var uploader = _fileUploaders.First(e => e.Type == ReportType.Esss);
            uploader.Delete(actionUserId);
        }

        [HttpDelete]
        [Route("~/reports/{actionUserId}/ndfl-6/delete")]
        public void DeleteNdfl6(int actionUserId)
        {
            var uploader = _fileUploaders.First(e => e.Type == ReportType.SixNdfl);
            uploader.Delete(actionUserId);
        }
    }
}
