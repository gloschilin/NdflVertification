using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.SixNdflValidators
{
    /// <summary>
    /// Быть годовой, а не квартальной. Проверка по периоду.
    /// </summary>
    internal class SixNdflPeriodStepValidator: BaseReportStepValidator<SixNdfl>
    {
        public SixNdflPeriodStepValidator(IValidationResultHandler validationResultHandler) 
            : base(validationResultHandler)
        {
        }

        private const string PeriodAttributeValue = "34";

        protected override CheckReportType CheckReportType => CheckReportType.SixNdflPeriod;
        public override bool IsSpecificatiedBy(SixNdfl entity)
        {
            return entity.Document.Period == PeriodAttributeValue;
        }
    }
}