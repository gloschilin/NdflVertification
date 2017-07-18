using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.Total
{
    public class Total24Validator : BaseReportStepValidator<Reports>
    {
        public Total24Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Total24Validator;

        public override bool IsSpecificatiedBy(Reports entity)
        {
            if (entity.Esss == null || entity.Ndfl6 == null)
            {
                return true;
            }

            return (entity.Esss.Документ.КНД == "1151099" || entity.Ndfl6.Документ.КНД == "1151099");
        }
    }
}