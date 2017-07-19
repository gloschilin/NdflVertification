using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv187Validator : BaseReportStepValidator<Файл>
    {
        public Sv187Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv187Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВ.СумВсегоПер,
                    0
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВ.СумВсегоПосл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }
}