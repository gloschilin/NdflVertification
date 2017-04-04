using System;
using System.Linq;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv12Validator : BaseReportStepValidator<Файл>
    {
        // ОЧЕНЬ НА 1.1 ПОХОЖА
        /// <summary>
        /// сумма СВ на ОМС за отчетный период  сумме СВ на ОМС за предыдущий отчетный период 
        ///  и за последние три месяца отчетного периода
        /// </summary>
        /// <param name="validationResultHandler"></param>
        public Sv12Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv12Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (entity.Документ.РасчетСВ.ОбязПлатСВ.УплПерОПС.СумСВУплПер !=
                0 + // <РасчетСВ> <УплПерОПС СумСВУплПер="ХХХ" поп
                entity.Документ.РасчетСВ.ОбязПлатСВ.УплПерОПС.СумСВУпл1М +
                entity.Документ.РасчетСВ.ОбязПлатСВ.УплПерОПС.СумСВУпл2М +
                entity.Документ.РасчетСВ.ОбязПлатСВ.УплПерОПС.СумСВУпл3М)
            {
                return false;
            }

            return true;
        }
    }
}
