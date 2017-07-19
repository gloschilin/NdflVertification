using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.Total
{
    public class Total23Validator : BaseReportStepValidator<Reports>
    {
        public Total23Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Reports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Total23Validator;

        public override bool IsSpecificatiedBy(Reports entity)
        {
            if (entity.Esss == null || entity.Ndfl6 == null)
            {
                return true;
            }

            return (entity.Esss.Документ.КНД == "1151111" || entity.Ndfl6.Документ.КНД == "1151111");
        }
    }
}