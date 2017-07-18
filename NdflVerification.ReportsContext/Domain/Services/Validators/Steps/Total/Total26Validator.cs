using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.Total
{
    public class Total26Validator : BaseReportStepValidator<Reports>
    {
        public Total26Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Total26Validator;
        public override bool IsSpecificatiedBy(Reports entity)
        {
            if (entity.Esss == null || entity.Ndfl6 == null)
            {
                return true;
            }

            return entity.Esss.Документ.Период == entity.Ndfl6.Документ.Период
                   && entity.Esss.Документ.ОтчетГод == entity.Ndfl6.Документ.ОтчетГод;
        }
    }
}