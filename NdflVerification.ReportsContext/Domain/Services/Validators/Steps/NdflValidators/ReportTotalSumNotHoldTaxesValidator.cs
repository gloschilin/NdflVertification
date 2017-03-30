using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.NdflValidators
{
    /// <summary>
    /// Общая сумма не удержанных налогов за год.
    /// </summary>
    internal class ReportTotalSumNotHoldTaxesValidator : BaseReportStepValidator<Reports>
    {
        public ReportTotalSumNotHoldTaxesValidator(IValidationResultHandler validationResultHandler)
            : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.ReportsTotalSumNotHoldTaxes;

        public override bool IsSpecificatiedBy(Reports entity)
        {
            return entity.SixNdfl.GetTotalNotHoldTaxesSum() == entity.TwoNdfl.GetTotalNotHoldTaxesSum();
        }
    }
}