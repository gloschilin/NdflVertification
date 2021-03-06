﻿using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using NdflVerification.ReportsContext.Domain.Services.Factories;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;
using NdflVertification.Web.Api.Utils;

namespace NdflVertification.Web.Api.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EsssApiController : ApiController
    {
        private readonly IReportFactory<Файл> _essReportFactory;
        private readonly IReportValidator<Файл> _validator;

        public EsssApiController(IReportFactory<Файл> essReportFactory, IReportValidator<Файл> validator)
        {
            _essReportFactory = essReportFactory;
            _validator = validator;
        }

        [HttpGet]
        [Route("~/reports/{actionUserId}/esss")]
        public IHttpActionResult Validate(int actionUserId)
        {
            string path = $"~/Files/{actionUserId}";
            var file =
                _essReportFactory.ReadFromLocalFile(
                    System.Web.Hosting.HostingEnvironment.MapPath($"{path}/esss.file"));
            _validator.Validate(file);

            var result = HttpContext.Current.Items["WebValidationResultHandler"] as List<WebValidationInfo> 
                ?? new List<WebValidationInfo>();

            return Ok(result.Where(e=>e.Status == ValidationResultType.Error));
        }
    }
}
