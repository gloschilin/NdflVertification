using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.NdflValidators
{
    /// <summary>
    /// Общая сумма начисленных налогов за год.
    /// </summary>
    internal class ReportTotalSumTaxesValidator : BaseReportStepValidator<Reports>
    {
        public ReportTotalSumTaxesValidator(IValidationResultHandler validationResultHandler)
            : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.ReportsTotalSumTaxes;

        public override bool IsSpecificatiedBy(Reports entity)
        {
            return entity.SixNdfl.GetTotalTaxesSum() == entity.TwoNdfl.GetTotalTaxesSum();
        }
    }
}