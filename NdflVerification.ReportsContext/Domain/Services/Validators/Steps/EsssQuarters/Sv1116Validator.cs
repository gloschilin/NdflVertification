using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssQuarters
{
    public class Sv1116Validator : BaseReportStepValidator<EsssReports>
    {
        public Sv1116Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<EsssReports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1116Validator;

        public override bool IsSpecificatiedBy(EsssReports entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Current.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (entity.Previous == null)
                {
                    if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.НеОбложенСВ.СумВсегоПер !=
                    0
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.НеОбложенСВ.СумВсегоПосл3М)
                    {
                        return false;
                    }
                }
                else
                {
                    foreach (var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмсПоп in entity.Previous.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
                    {
                        if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.НеОбложенСВ.СумВсегоПер !=
                        файлДокументРасчетСвОбязПлатСвРасчСвОпсОмсПоп.РасчСВ_ОМС.НеОбложенСВ.СумВсегоПер
                        + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.НеОбложенСВ.СумВсегоПосл3М)
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