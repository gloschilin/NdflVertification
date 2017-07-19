using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1121Validator : BaseReportStepValidator<Файл>
    {
        public Sv1121Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1121Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.БазНачислСВ.Сум2Посл3М,
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.ВыплНачислФЛ.Сум2Посл3М
                    - файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.НеОбложенСВ.Сум2Посл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }
}