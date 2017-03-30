using System.Linq;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.TwoNdflValidators
{
    /// <summary>
    ///  Являться формой 2-НДФЛ, а не другой формой отчета. Проверка по форме.
    /// </summary>
    internal class TwoNdflFormStepValidator: BaseReportStepValidator<TwoNdfl>
    {
        public TwoNdflFormStepValidator(IValidationResultHandler validationResultHandler) 
            : base(validationResultHandler)
        {
        }

        private const string DocumentKndAttributeValue = "1151078";

        protected override CheckReportType CheckReportType => CheckReportType.TwoNdflFrom;
        public override bool IsSpecificatiedBy(TwoNdfl entity)
        {
            return entity.Documents.All(e => e.Knd == DocumentKndAttributeValue);
        }
    }
}
