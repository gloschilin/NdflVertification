using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssQuarters
{
    public class Sv1233Validator : BaseReportStepValidator<EsssReports>
    {
        public Sv1233Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<EsssReports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1233Validator;

        public override bool IsSpecificatiedBy(EsssReports entity)
        {
            if (entity.Previous == null)
            {
                if (!AllEquals(entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВФарм.СумВсегоПер,
                0
                + entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВФарм.СумВсегоПосл3М))
                {
                    return false;
                }
            }
            else
            {
                if (!AllEquals(entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВФарм.СумВсегоПер,
                entity.Previous.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВФарм.СумВсегоПер
                + entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВФарм.СумВсегоПосл3М))
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}