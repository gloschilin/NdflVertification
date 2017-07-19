using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssQuarters
{
    public class Sv14Validator : BaseReportStepValidator<EsssReports>
    {
        /// <summary>
        /// сумма СВ на ДСО за отчетный период  сумме СВ на ДСО за предыдущий отчетный период
        ///  и за последние три месяца отчетного периода по каждому КБК
        /// </summary>
        /// <param name="validationResultHandler"></param>
        /// <param name="reportQuarterHelper"></param>
        public Sv14Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<EsssReports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv14Validator;

        public override bool IsSpecificatiedBy(EsssReports entity)
        {
            if (entity.Current.Документ.РасчетСВ.ОбязПлатСВ.УплПерДСО == null)
            {
                return true;
            }

            foreach(var item in entity.Current.Документ.РасчетСВ.ОбязПлатСВ.УплПерДСО)
            {
                if (entity.Previous == null)
                {
                    if (item.СумСВУплПер !=
                    0 + // <РасчетСВ> <УплПерДСО СумСВУплПер="ХХХ" поп
                    item.СумСВУпл1М +
                    item.СумСВУпл2М +
                    item.СумСВУпл3М)
                    {
                        return false;
                    }
                }
                else
                {
                    if (entity.Previous.Документ.РасчетСВ.ОбязПлатСВ.УплПерДСО == null)
                    {
                        return false;
                    }

                    foreach (var itemПоп in entity.Previous.Документ.РасчетСВ.ОбязПлатСВ.УплПерДСО)
                    {
                        if (item.СумСВУплПер !=
                        itemПоп.СумСВУплПер + // <РасчетСВ> <УплПерДСО СумСВУплПер="ХХХ" поп
                        item.СумСВУпл1М +
                        item.СумСВУпл2М +
                        item.СумСВУпл3М)
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
