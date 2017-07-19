using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1238Validator : BaseReportStepValidator<Файл>
    {
        public Sv1238Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1238Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (!AllEquals(entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВПат.СумВсегоПосл3М,
                entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВПат.Сум1Посл3М
                + entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВПат.Сум2Посл3М
                + entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВПат.Сум3Посл3М))
            {
                return false;
            }
            return true;
        }
    }
}