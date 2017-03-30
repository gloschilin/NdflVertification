using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.NdflValidators
{
    /// <summary>
    /// Общая сумма дохода за год.
    /// </summary>
    internal class ReportTotalSumValidator: BaseReportStepValidator<Reports>
    {
        public ReportTotalSumValidator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.ReportsTotalSum;

        public override bool IsSpecificatiedBy(Reports entity)
        {
            return entity.SixNdfl.GetTotalSum() == entity.TwoNdfl.GetTotalSum();
        }
    }
}