using System.Linq;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps
{
    /// <summary>
    /// Проверка по ИНН и КПП.
    /// </summary>
    internal class ReportsInnAndKppStepValidator: BaseReportStepValidator<Reports>
    {
        public ReportsInnAndKppStepValidator(IValidationResultHandler validationResultHandler) 
            : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.ReportsInnAndKpp;
        public override bool IsSpecificatiedBy(Reports entity)
        {
            return entity.TwoNdfl.Documents.All(e => e.Inn == entity.SixNdfl.Inn && e.Kpp == entity.SixNdfl.Kpp);
        }
    }
}
