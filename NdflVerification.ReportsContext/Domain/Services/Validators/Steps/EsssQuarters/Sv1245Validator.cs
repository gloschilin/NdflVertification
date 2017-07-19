using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssQuarters
{
    public class Sv1245Validator : BaseReportStepValidator<EsssReports>
    {
        public Sv1245Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<EsssReports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1245Validator;

        public override bool IsSpecificatiedBy(EsssReports entity)
        {
            if (entity.Previous == null)
            {
                if (!AllEquals(entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.ВозмРасхСО.СумВсегоПер,
                0
                + entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.ВозмРасхСО.СумВсегоПосл3М))
                {
                    return false;
                }
            }
            else
            {
                if (!AllEquals(entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.ВозмРасхСО.СумВсегоПер,
                entity.Previous.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.ВозмРасхСО.СумВсегоПер
                + entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.ВозмРасхСО.СумВсегоПосл3М))
                {
                    return false;
                }
            }

            
            return true;
        }
    }
}