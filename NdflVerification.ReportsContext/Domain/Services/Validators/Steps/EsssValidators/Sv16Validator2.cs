using System;
using System.Linq;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv16Validator2 : BaseReportStepValidator<Файл>
    {
        /// <summary>
        /// сумма СВ на ОПС к уплате за отчетный период  сумме исчисленных СВ на ОПС 
        ///  за отчетный период по каждому виду тарифа
        /// </summary>
        /// <param name="validationResultHandler"></param>
        public Sv16Validator2(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv16Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (entity.Документ.РасчетСВ.ОбязПлатСВ.УплПерОПС.СумСВУплПер !=
                entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(s => s.РасчСВ_ОПС.НачислСВ.СумВсегоПер))
            {
                return false;
            }

            return true;
        }
    }
}
