﻿using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssQuarters
{
    public class Sv11Validator : BaseReportStepValidator<EsssReports>
    {
        /// <summary>
        /// сумма СВ на ОПС за отчетный период  сумме СВ на ОПС за предыдущий отчетный период
        ///  и за последние три месяца отчетного периода
        /// </summary>
        /// <param name="validationResultHandler"></param>
        /// <param name="reportQuarterHelper"></param>
        public Sv11Validator(IValidationResultHandler validationResultHandler, 
            IReportQuarterHelper<EsssReports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv11Validator;

        public override bool IsSpecificatiedBy(EsssReports entity)
        {
            if (entity.Previous == null)
            {
                if (entity.Current.Документ.РасчетСВ.ОбязПлатСВ.УплПерОПС.СумСВУплПер !=
                0 + // <РасчетСВ> <УплПерОПС СумСВУплПер="ХХХ" поп
                entity.Current.Документ.РасчетСВ.ОбязПлатСВ.УплПерОПС.СумСВУпл1М +
                entity.Current.Документ.РасчетСВ.ОбязПлатСВ.УплПерОПС.СумСВУпл2М +
                entity.Current.Документ.РасчетСВ.ОбязПлатСВ.УплПерОПС.СумСВУпл3М)
                {
                    return false;
                }
            }
            else
            {
                if (entity.Current.Документ.РасчетСВ.ОбязПлатСВ.УплПерОПС.СумСВУплПер !=
                entity.Previous.Документ.РасчетСВ.ОбязПлатСВ.УплПерОПС.СумСВУплПер +
                entity.Current.Документ.РасчетСВ.ОбязПлатСВ.УплПерОПС.СумСВУпл1М +
                entity.Current.Документ.РасчетСВ.ОбязПлатСВ.УплПерОПС.СумСВУпл2М +
                entity.Current.Документ.РасчетСВ.ОбязПлатСВ.УплПерОПС.СумСВУпл3М)
                {
                    return false;
                }
            }
            

            return true;
        }
    }
}
