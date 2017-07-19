using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssQuarters
{
    public class Sv1237Validator : BaseReportStepValidator<EsssReports>
    {
        public Sv1237Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<EsssReports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1237Validator;

        public override bool IsSpecificatiedBy(EsssReports entity)
        {
            if (entity.Previous == null)
            {
                if (!AllEquals(entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВПат.СумВсегоПер,
                0
                + entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВПат.СумВсегоПосл3М))
                {
                    return false;
                }
            }
            else
            {
                if (!AllEquals(entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВПат.СумВсегоПер,
                entity.Previous.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВПат.СумВсегоПер
                + entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВПат.СумВсегоПосл3М))
                {
                    return false;
                }
            }

            return true;
        }
    }
}