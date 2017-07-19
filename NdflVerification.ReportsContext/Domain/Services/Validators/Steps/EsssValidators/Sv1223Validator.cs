using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1223Validator : BaseReportStepValidator<Файл>
    {
        public Sv1223Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1223Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (!AllEquals(
                entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачислСВ.СумВсегоПосл3М,
                entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.ВыплНачислФЛ.СумВсегоПосл3М
                - entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.НеОбложенСВ.СумВсегоПосл3М
                - entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазПревышСВ.СумВсегоПосл3М))
            {
                return false;
            }
            return true;
        }
    }
}