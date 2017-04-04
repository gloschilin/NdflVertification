using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1243Validator : BaseReportStepValidator<Файл>
    {
        public Sv1243Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1243Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (!AllEquals(entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.ПроизвРасхСО.СумВсегоПер,
                0
                + entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.ПроизвРасхСО.СумВсегоПосл3М))
            {
                return false;
            }
            return true;
        }
    }
}