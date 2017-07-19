using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;
using NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssQuarters
{
    public class Sv1103Validator : BaseReportStepValidator<EsssReports>
    {
        public Sv1103Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<EsssReports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1103Validator;

        public override bool IsSpecificatiedBy(EsssReports entity)
        {
            foreach (var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (entity.Previous == null)
                {
                    if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.КолЛицНачСВВс.КолВсегоПер.ToInt() < 0)
                    {
                        return false;
                    }
                }
                else
                {
                    foreach (var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмсПоп in entity.Previous.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
                    {
                        if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.КолЛицНачСВВс.КолВсегоПер.ToInt() <
                            файлДокументРасчетСвОбязПлатСвРасчСвОпсОмсПоп.РасчСВ_ОМС.КолЛицНачСВВс.КолВсегоПер.ToInt())
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