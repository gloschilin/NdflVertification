using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.NdflEsssValidators
{
    public class Total21Validator : BaseReportStepValidator<NdflEssReports>
    {
        public Total21Validator(IValidationResultHandler validationResultHandler, 
            IReportQuarterHelper<NdflEssReports> reportQuarterHelper) 
            : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Total21Validator;
        public override bool IsSpecificatiedBy(NdflEssReports entity)
        {
            if (entity.Ndfl != null && entity.Esss == null)
            {
                return false;
            }

            return true;
        }
    }
}
