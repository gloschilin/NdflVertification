using System;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv163Validator : BaseReportStepValidator<Файл>
    {
        public Sv163Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv163Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НеОбложенСВ.СумВсегоПер,
                    0
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НеОбложенСВ.СумВсегоПосл3М))
                {
                    return false;
                }
            }

            return true;
        }
    }
}