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
        public Sv13Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv13Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach(var item in entity.Документ.РасчетСВ.ОбязПлатСВ.УплПерОПСДоп)
            {
                if (item.СумСВУплПер !=
                    0 + // <РасчетСВ> <УплПерОПСДоп СумСВУплПер="ХХХ" поп
                    item.СумСВУпл1М +
                    item.СумСВУпл2М +
                    item.СумСВУпл2М) //по каждому значению <РасчетСВ> <УплПерОПСДоп КБК="ХХХ" оп
                    // тут похоже 3 ??????
                {
                    return false;
                }
            }

            return true;
        }
    }
}
