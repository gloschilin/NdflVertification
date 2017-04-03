using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1226Validator : BaseReportStepValidator<Файл>
    {
        public Sv1226Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1226Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (!AllEquals(
                entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачислСВ.Сум3Посл3М,
                entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.ВыплНачислФЛ.Сум3Посл3М
                - entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.НеОбложенСВ.Сум3Посл3М
                - entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазПревышСВ.Сум3Посл3М))
            {
                return false;
            }
            return true;
        }
    }
}