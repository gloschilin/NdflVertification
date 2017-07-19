using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1232Validator : BaseReportStepValidator<Файл>
    {
        public Sv1232Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1232Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (!AllEquals(entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачислСВ.СумВсегоПосл3М,
                entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачислСВ.Сум1Посл3М
                + entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачислСВ.Сум2Посл3М
                + entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачислСВ.Сум3Посл3М))
            {
                return false;
            }
            return true;
        }
    }
}