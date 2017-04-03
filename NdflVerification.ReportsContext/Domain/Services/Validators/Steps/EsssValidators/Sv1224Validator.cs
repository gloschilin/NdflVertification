using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1224Validator : BaseReportStepValidator<Файл>
    {
        public Sv1224Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1224Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (!AllEquals(
                entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачислСВ.Сум1Посл3М,
                entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.ВыплНачислФЛ.Сум1Посл3М
                - entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.НеОбложенСВ.Сум1Посл3М
                - entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазПревышСВ.Сум1Посл3М))
            {
                return false;
            }
            return true;
        }
    }
}