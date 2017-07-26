using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.FullReportsValidators
{
    /// <summary>
    /// Обязательность заполенния предыдущего квартала отчетности если не заполенен предыдущий
    /// </summary>
    public class EsssQuartersCorrectlyValidator : BaseReportStepValidator<Reports>
    {
        public EsssQuartersCorrectlyValidator(IValidationResultHandler validationResultHandler, 
            IReportQuarterHelper<Reports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {

        }

        protected override CheckReportType CheckReportType => CheckReportType.EsssQuartersCorrectlyValidator;
        public override bool IsSpecificatiedBy(Reports entity)
        {
            if (entity.Esss2 != null && entity.Esss1 == null
                || entity.Esss3 != null && entity.Esss2 == null
                || entity.Esss4 != null && entity.Esss3 == null)
            {
                return false;
            }
            return true;
        }
    }
}
