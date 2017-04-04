using System.Diagnostics;
using NdflVerification.ReportsContext.Domain.Services.Validators;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVertification.Web.Api.Utils
{
    public class WebValidationResultHandler: IValidationResultHandler
    {
        public void Handle(CheckReportType checkReportType, ValidationResultType validationResultType)
        {
            Debug.WriteLine($"{checkReportType} : {validationResultType}");
        }
    }
}