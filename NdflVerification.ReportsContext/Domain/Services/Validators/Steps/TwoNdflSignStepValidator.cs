using System.Linq;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps
{
    /// <summary>
    /// Иметь признак 1. Проверка по признаку.
    /// </summary>
    internal class TwoNdflSignStepValidator: BaseReportStepValidator<TwoNdfl>
    {
        public TwoNdflSignStepValidator(IValidationResultHandler validationResultHandler) 
            : base(validationResultHandler)
        {
        }

        private const string SignAttributeValue = "1";

        protected override CheckReportType CheckReportType => CheckReportType.TwoNdflSign;
        public override bool IsSpecificatiedBy(TwoNdfl entity)
        {
            return entity.Documents.All(e => e.Sign == SignAttributeValue);
        }
    }
}