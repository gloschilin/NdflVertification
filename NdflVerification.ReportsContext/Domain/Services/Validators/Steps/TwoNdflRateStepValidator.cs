using System.Linq;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps
{
    /// <summary>
    /// Предусматривать расчет налога по ставке 13%. Проверка по ставке.
    /// </summary>
    internal class TwoNdflRateStepValidator: BaseReportStepValidator<TwoNdfl>
    {
        public TwoNdflRateStepValidator(IValidationResultHandler validationResultHandler) 
            : base(validationResultHandler)
        {
        }

        private const string RateAttributeValue = "13";
        protected override CheckReportType CheckReportType => CheckReportType.TwoNdflRate;
        public override bool IsSpecificatiedBy(TwoNdfl entity)
        {
            return entity.Documents.All(e => e.Rate == RateAttributeValue);
        }
    }
}