using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1246Validator : BaseReportStepValidator<Файл>
    {
        public Sv1246Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1246Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (!AllEquals(entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.ВозмРасхСО.СумВсегоПосл3М,
                entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.ВозмРасхСО.Сум1Посл3М
                + entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.ВозмРасхСО.Сум2Посл3М
                + entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.ВозмРасхСО.Сум3Посл3М))
            {
                return false;
            }
            return true;
        }
    }
}