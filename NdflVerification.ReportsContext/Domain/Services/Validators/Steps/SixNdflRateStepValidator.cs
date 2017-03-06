using System.Linq;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps
{
    /// <summary>
    /// Предусматривать расчет налога по ставке 13%. Проверка на ставку.
    /// </summary>
    internal class SixNdflRateStepValidator: BaseReportStepValidator<SixNdfl>
    {
        public SixNdflRateStepValidator(IValidationResultHandler validationResultHandler) 
            : base(validationResultHandler)
        {
        }

        private const string RateAttributeValue = "13";
        protected override CheckReportType CheckReportType => CheckReportType.SixNdflRate;
        public override bool IsSpecificatiedBy(SixNdfl entity)
        {
            return entity.Document.SumRates.All(e => e.Rate == RateAttributeValue);
        }
    }
}