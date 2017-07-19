using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;
using NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssQuarters
{
    public class Sv1194Validator : BaseReportStepValidator<EsssReports>
    {
        public Sv1194Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<EsssReports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1194Validator;

        public override bool IsSpecificatiedBy(EsssReports entity)
        {
            if (entity.Previous == null)
            {
                if (entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.КолСтрахЛицВс.КолВсегоПер.ToInt() < 0)
                {
                    return false;
                }
            }
            else
            {
                if (entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.КолСтрахЛицВс.КолВсегоПер.ToInt() <
                    entity.Previous.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.КолСтрахЛицВс.КолВсегоПер.ToInt())
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}