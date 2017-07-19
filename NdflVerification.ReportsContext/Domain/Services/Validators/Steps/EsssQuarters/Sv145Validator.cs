using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;
using NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssQuarters
{
    public class Sv145Validator : BaseReportStepValidator<EsssReports>
    {
        public Sv145Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<EsssReports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv145Validator;

        public override bool IsSpecificatiedBy(EsssReports entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (entity.Previous == null)
                {
                    if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолЛицНачСВВс.КолВсегоПер.ToInt() < 0)
                    {
                        return false;
                    }
                }
                else
                {
                    foreach (var документРасчетСвОбязПлатСвРасчСвОпсОмсПоп in entity.Previous.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
                    {
                        if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолЛицНачСВВс.КолВсегоПер.ToInt() <
                            документРасчетСвОбязПлатСвРасчСвОпсОмсПоп.РасчСВ_ОПС.КолЛицНачСВВс.КолВсегоПер.ToInt())
                        {
                            return false;
                        }
                    }
                }
                
            }

            return true;
        }
    }
}