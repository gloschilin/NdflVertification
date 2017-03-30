using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.NdflValidators
{
    /// <summary>
    /// Общая сумма дивидендов за год.
    /// </summary>
    internal class ReportTotalSumDividendsValidator : BaseReportStepValidator<Reports>
    {
        public ReportTotalSumDividendsValidator(IValidationResultHandler validationResultHandler) 
            : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.ReportsTotalSumDividends;

        public override bool IsSpecificatiedBy(Reports entity)
        {
            return entity.SixNdfl.GetTotalDividendsSum() == entity.TwoNdfl.GetTotalDividendsSum();
        }
    }
}