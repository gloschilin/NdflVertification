using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.NdflEsssValidators
{
    public class Total24Validator : BaseReportStepValidator<NdflEssReports>
    {
        public Total24Validator(IValidationResultHandler validationResultHandler, 
            IReportQuarterHelper<NdflEssReports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Total24Validator;

        public override bool IsSpecificatiedBy(NdflEssReports entity)
        {
            if (entity.Esss == null || entity.Ndfl == null)
            {
                return true;
            }

            return (entity.Esss.Документ.КНД == "1151099" || entity.Ndfl.Документ.КНД == "1151099");
        }
    }
}