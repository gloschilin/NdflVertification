using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.NdflEsssValidators
{
    public class Total23Validator : BaseReportStepValidator<NdflEssReports>
    {
        public Total23Validator(IValidationResultHandler validationResultHandler, 
            IReportQuarterHelper<NdflEssReports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Total23Validator;

        public override bool IsSpecificatiedBy(NdflEssReports entity)
        {
            if (entity.Esss == null || entity.Ndfl == null)
            {
                return true;
            }

            return (entity.Esss.Документ.КНД == "1151111" || entity.Ndfl.Документ.КНД == "1151111");
        }
    }
}