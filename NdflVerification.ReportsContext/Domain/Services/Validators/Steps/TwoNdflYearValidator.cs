using System.Linq;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps
{
    /// <summary>
    ///  Проверка по дате.
    /// </summary>
    internal class TwoNdflYearValidator: BaseReportStepValidator<TwoNdfl>
    {
        public TwoNdflYearValidator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.TwoNdflYear;
        public override bool IsSpecificatiedBy(TwoNdfl entity)
        {
            return entity.Documents.All(e => e.ReportYear == entity.ReportYear);
        }
    }
}