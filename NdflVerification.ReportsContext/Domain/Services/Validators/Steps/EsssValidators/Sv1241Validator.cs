using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1241Validator : BaseReportStepValidator<Файл>
    {
        public Sv1241Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1241Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (!AllEquals(entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.НачислСВ.СумВсегоПер,
                0
                + entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.НачислСВ.СумВсегоПосл3М))
            {
                return false;
            }
            return true;
        }
    }
}