using System;
using System.Linq;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv13Validator : BaseReportStepValidator<Файл>
    {
        /// <summary>
        /// сумма СВ на ОПС по дополнительному тарифу за отчетный период 
        ///  сумме СВ на ОПС по дополнительному тарифу за предыдущий отчетный период
        ///  и за последние три месяца отчетного периода по каждому КБК
        /// </summary>
        /// <param name="validationResultHandler"></param>
        /// <param name="reportQuarterHelper"></param>
        public Sv13Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv13Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (entity.Документ.РасчетСВ.ОбязПлатСВ.УплПерОПСДоп == null)
            {
                return true;
            }

            foreach(var item in entity.Документ.РасчетСВ.ОбязПлатСВ.УплПерОПСДоп)
            {
                if (item.СумСВУплПер !=
                    0 + // <РасчетСВ> <УплПерОПСДоп СумСВУплПер="ХХХ" поп
                    item.СумСВУпл1М +
                    item.СумСВУпл2М +
                    item.СумСВУпл3М)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
