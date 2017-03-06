using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace NdflVerification.Api.Controllers
{
    /// <summary>
    /// Обработка данных сессии отчетности
    /// </summary>
    public interface IReportSession
    {
        /// <summary>
        /// Получить текущую сессию загрузки отчетности
        /// </summary>
        /// <returns></returns>
        Guid GetCurrentSession();

        /// <summary>
        /// Создать новую сессию загрузки отчетнотси
        /// </summary>
        /// <param name="sesssionId"></param>
        void CreateSession(Guid sesssionId);

        /// <summary>
        /// Проверка на наличии сессии загрузки отчетности
        /// </summary>
        /// <returns></returns>
        bool Exists();
    }

    public class ReportValidationResult
    {

    }

    public class ReportsController : ApiController
    {
        [HttpPost]
        [Route("api/reports/ndfl-6")]
        public IHttpActionResult Load6Ndfl(HttpPostedFile reportFile)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("api/reports/ndfl-2")]
        public IHttpActionResult Load2Ndfl(HttpPostedFile reportFile)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("api/reports/ndfl-6")]
        public IEnumerable<ReportValidationResult> Validate6Ndfl()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("api/reports/ndfl-2")]
        public IEnumerable<ReportValidationResult> Validate2Ndfl()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("api/reports")]
        public IEnumerable<ReportValidationResult> ValidateReports()
        {
            throw new NotImplementedException();
        }
    }
}
