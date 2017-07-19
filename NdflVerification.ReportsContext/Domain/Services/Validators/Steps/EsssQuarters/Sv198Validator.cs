using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;
using NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssQuarters
{
    public class Sv198Validator : BaseReportStepValidator<EsssReports>
    {
        public Sv198Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<EsssReports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv198Validator;

        public override bool IsSpecificatiedBy(EsssReports entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (entity.Previous == null)
                {
                    if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.КолСтрахЛицВс.КолВсегоПер.ToInt() < 0)
                    {
                        return false;
                    }
                }
                else
                {
                    foreach (
                        var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмсПоп in
                            entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
                    {
                        if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.КолСтрахЛицВс.КолВсегоПер.ToInt() <
                            файлДокументРасчетСвОбязПлатСвРасчСвОпсОмсПоп.РасчСВ_ОМС.КолСтрахЛицВс.КолВсегоПер.ToInt())
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