using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.Total
{
    public class Total21Validator : BaseReportStepValidator<Reports>
    {
        public Total21Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Reports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Total21Validator;
        public override bool IsSpecificatiedBy(Reports entity)
        {
            if (entity.Ndfl6 != null && entity.Esss == null)
            {
                return false;
            }

            return true;
        }
    }
}
