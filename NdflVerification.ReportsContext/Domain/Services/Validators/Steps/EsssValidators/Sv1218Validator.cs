using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1218Validator : BaseReportStepValidator<Файл>
    {
        public Sv1218Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1218Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (!AllEquals(
                entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.НеОбложенСВ.СумВсегоПосл3М,
                entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.НеОбложенСВ.Сум1Посл3М
                + entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.НеОбложенСВ.Сум2Посл3М
                + entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.НеОбложенСВ.Сум3Посл3М
                ))
            {
                return false;
            }
            return true;
        }
    }
}