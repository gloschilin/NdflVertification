using System;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv156Validator : BaseReportStepValidator<Файл>
    {
        public Sv156Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv156Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПер,
                    0 
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПосл3М))
                {
                    return false;
                }
            }

            return true;
        }
    }
}