using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;
using NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssQuarters
{
    public class Sv135Validator : BaseReportStepValidator<EsssReports>
    {
        public Sv135Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<EsssReports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv135Validator;

        public override bool IsSpecificatiedBy(EsssReports entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (entity.Previous == null)
                {
                    if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолСтрахЛицВс.КолВсегоПер.ToInt()
                    < 0)
                    {
                        return false;
                    }
                }
                else
                {
                    foreach (var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмсПоп in entity.Previous.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
                    {
                        if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолСтрахЛицВс.КолВсегоПер.ToInt()
                        < файлДокументРасчетСвОбязПлатСвРасчСвОпсОмсПоп.РасчСВ_ОПС.КолСтрахЛицВс.КолВсегоПер.ToInt())
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