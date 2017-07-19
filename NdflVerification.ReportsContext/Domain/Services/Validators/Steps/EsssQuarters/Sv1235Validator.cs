using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssQuarters
{
    public class Sv1235Validator : BaseReportStepValidator<EsssReports>
    {
        public Sv1235Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<EsssReports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1235Validator;

        public override bool IsSpecificatiedBy(EsssReports entity)
        {
            if (entity.Previous == null)
            {
                if (!AllEquals(entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВЧлЭС.СумВсегоПер,
                0
                + entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВЧлЭС.СумВсегоПосл3М))
                {
                    return false;
                }
            }
            else
            {
                if (!AllEquals(entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВЧлЭС.СумВсегоПер,
                entity.Previous.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВЧлЭС.СумВсегоПер
                + entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВЧлЭС.СумВсегоПосл3М))
                {
                    return false;
                }
            }

            
            return true;
        }
    }
}