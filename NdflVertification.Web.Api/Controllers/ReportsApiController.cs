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
        private readonly IEnumerable<IReportFactory<NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Six.Файл>> _ndfl6Factries;
        private readonly IEnumerable<IFileUploader> _fileUploaders;
        private readonly IReportResultValidator _reportValidator;

        public ReportsApiController(IReportResultValidator reportValidator,
            IEnumerable<IReportFactory<NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss.Файл>> esssFactories, 
            IEnumerable<IReportFactory<NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Six.Файл>> ndfl6Factries,
            IEnumerable<IFileUploader> fileUploaders)
        {
            _reportValidator = reportValidator;
            _esssFactories = esssFactories;
            _ndfl6Factries = ndfl6Factries;
            _fileUploaders = fileUploaders;
        }

        private static IEnumerable<ReportType> NdflTypes => new[]
        {
            ReportType.SixNdfl1,
            ReportType.SixNdfl2,
            ReportType.SixNdfl3,
            ReportType.SixNdfl4
        };
        private static IEnumerable<ReportType> EsssTypes => new[]
        {
            ReportType.Esss1,
            ReportType.Esss2,
            ReportType.Esss3,
            ReportType.Esss4
        };

        [HttpGet]
        [Route("~/reports/{actionUserId}")]
        public IHttpActionResult Validate(int actionUserId)
        {
            var reports = new Reports();

            foreach (var fileUploader in _fileUploaders.Where(e=> NdflTypes.Contains(e.Type)))
            {
                if (!fileUploader.Exists(actionUserId)) continue;
                var factory = _ndfl6Factries.Single(e => e.ReportType == fileUploader.Type);
                var file = factory.ReadFromLocalFile(fileUploader.Path(actionUserId));
                reports.SetNdfl(file, fileUploader.Type);
            }

            foreach (var fileUploader in _fileUploaders.Where(e=> EsssTypes.Contains(e.Type)))
            {
                if (!fileUploader.Exists(actionUserId)) continue;
                var factory = _esssFactories.Single(e => e.ReportType == fileUploader.Type);
                var file = factory.ReadFromLocalFile(fileUploader.Path(actionUserId));
                reports.SetEsss(file, fileUploader.Type);
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
                    case ReportType.SixNdfl1:
                        info.Ndfl61 = exists;
                        break;
                    case ReportType.SixNdfl2:
                        info.Ndfl62 = exists;
                        break;
                    case ReportType.SixNdfl3:
                        info.Ndfl63 = exists;
                        break;
                    case ReportType.SixNdfl4:
                        info.Ndfl64 = exists;
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
        [Route("~/reports/{actionUserId}/ndfl-61/delete")]
        public void DeleteNdfl61(int actionUserId)
        {
            var uploader = _fileUploaders.First(e => e.Type == ReportType.SixNdfl1);
            uploader.Delete(actionUserId);
        }

        [HttpDelete]
        [Route("~/reports/{actionUserId}/ndfl-62/delete")]
        public void DeleteNdfl62(int actionUserId)
        {
            var uploader = _fileUploaders.First(e => e.Type == ReportType.SixNdfl2);
            uploader.Delete(actionUserId);
        }

        [HttpDelete]
        [Route("~/reports/{actionUserId}/ndfl-63/delete")]
        public void DeleteNdfl63(int actionUserId)
        {
            var uploader = _fileUploaders.First(e => e.Type == ReportType.SixNdfl3);
            uploader.Delete(actionUserId);
        }

        [HttpDelete]
        [Route("~/reports/{actionUserId}/ndfl-64/delete")]
        public void DeleteNdfl64(int actionUserId)
        {
            var uploader = _fileUploaders.First(e => e.Type == ReportType.SixNdfl4);
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
