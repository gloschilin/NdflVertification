using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssQuarters
{
    public class Sv1239Validator : BaseReportStepValidator<EsssReports>
    {
        public Sv1239Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<EsssReports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1239Validator;

        public override bool IsSpecificatiedBy(EsssReports entity)
        {
            if (entity.Previous == null)
            {
                if (!AllEquals(entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВИнЛиц.СумВсегоПер,
                0
                + entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВИнЛиц.СумВсегоПосл3М))
                {
                    return false;
                }
            }
            else
            {
                if (!AllEquals(entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВИнЛиц.СумВсегоПер,
                entity.Previous.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВИнЛиц.СумВсегоПер
                + entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВИнЛиц.СумВсегоПосл3М))
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}