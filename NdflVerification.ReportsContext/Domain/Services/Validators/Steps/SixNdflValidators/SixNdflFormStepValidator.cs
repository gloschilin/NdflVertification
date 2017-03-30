using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.SixNdflValidators
{
    /// <summary>
    /// Являться формой 6-НДФЛ, а не другой формой отчета. Проверка по форме.
    /// </summary>
    internal class SixNdflFormStepValidator : BaseReportStepValidator<SixNdfl>
    {
        private const string KndValue = "1151099";

        public SixNdflFormStepValidator(IValidationResultHandler validationResultHandler) 
            : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.SixNdflForm;
        public override bool IsSpecificatiedBy(SixNdfl entity)
        {
            return entity.Document.Knd == KndValue;
        }
    }
}
