using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.NdflEsssValidators
{
    public class Total26Validator : BaseReportStepValidator<NdflEssReports>
    {
        public Total26Validator(IValidationResultHandler validationResultHandler, 
            IReportQuarterHelper<NdflEssReports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Total26Validator;
        public override bool IsSpecificatiedBy(NdflEssReports entity)
        {
            if (entity.Esss == null || entity.Ndfl == null)
            {
                return true;
            }

            return entity.Esss.Документ.Период == entity.Ndfl.Документ.Период
                   && entity.Esss.Документ.ОтчетГод == entity.Ndfl.Документ.ОтчетГод;
        }
    }
}