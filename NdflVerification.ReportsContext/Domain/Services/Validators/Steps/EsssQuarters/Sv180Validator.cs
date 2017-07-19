using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssQuarters
{
    public class Sv180Validator : BaseReportStepValidator<EsssReports>
    {
        public Sv180Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<EsssReports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv180Validator;

        public override bool IsSpecificatiedBy(EsssReports entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (entity.Previous == null)
                {
                    if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазНачислСВ.СумВсегоПер,
                    0 + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазНачислСВ.СумВсегоПосл3М))
                    {
                        return false;
                    }
                }
                else
                {
                    foreach (
                        var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмсПоп in
                            entity.Previous.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
                    {
                        if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазНачислСВ.СумВсегоПер,
                        файлДокументРасчетСвОбязПлатСвРасчСвОпсОмсПоп.РасчСВ_ОПС.БазНачислСВ.СумВсегоПер
                        + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазНачислСВ.СумВсегоПосл3М))
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