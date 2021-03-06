﻿using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssQuarters
{
    public class Sv15Validator : BaseReportStepValidator<EsssReports>
    {
        /// <summary>
        /// сумма СВ на ОСС за вычетом суммы превышения расходов над СВ ОСС за отчетный период 
        ///  сумме СВ на ОСС за предыдущий отчетный период и за последние три месяца отчетного 
        ///  периода за минусом суммы превышения расходов над СВ ОСС за предыдущий отчетный период 
        ///  и за последние три месяца отчетного периода
        /// </summary>
        /// <param name="validationResultHandler"></param>
        /// <param name="reportQuarterHelper"></param>
        public Sv15Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<EsssReports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv15Validator;

        public override bool IsSpecificatiedBy(EsssReports entity)
        {

            if (entity.Current.Документ.РасчетСВ.ОбязПлатСВ.УплПревОСС.УплПерОСС?.СумСВУплПер -
                entity.Current.Документ.РасчетСВ.ОбязПлатСВ.УплПревОСС.ПревРасхОСС?.ПревРасхСВПер !=
                (entity.Previous?.Документ.РасчетСВ.ОбязПлатСВ.УплПревОСС?.УплПерОСС.СумСВУплПер ?? 0) //<РасчетСВ> <УплПерОСС СумСВУплПер="ХХХ" поп  
                + entity.Current.Документ.РасчетСВ.ОбязПлатСВ.УплПревОСС.УплПерОСС?.СумСВУпл1М +
                entity.Current.Документ.РасчетСВ.ОбязПлатСВ.УплПревОСС.УплПерОСС?.СумСВУпл2М +
                entity.Current.Документ.РасчетСВ.ОбязПлатСВ.УплПревОСС.УплПерОСС?.СумСВУпл3М -
                ((entity.Previous?.Документ.РасчетСВ.ОбязПлатСВ.УплПревОСС?.ПревРасхОСС?.ПревРасхСВПер ?? 0) /* <РасчетСВ> <ПревРасхОСС ПревРасхСВПер="ХХХ" поп*/+
                 entity.Current.Документ.РасчетСВ.ОбязПлатСВ.УплПревОСС.ПревРасхОСС?.ПревРасхСВ1М +
                 entity.Current.Документ.РасчетСВ.ОбязПлатСВ.УплПревОСС.ПревРасхОСС?.ПревРасхСВ2М +
                 entity.Current.Документ.РасчетСВ.ОбязПлатСВ.УплПревОСС.ПревРасхОСС?.ПревРасхСВ3М
                )
            )
            {
                return false;
            }

            return true;
        }
    }
}
