using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv173Validator : BaseReportStepValidator<Файл>
    {
        public Sv173Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv173Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ПревБазОПС.Кол2Посл3М.ToDecimal() > 0
                    && файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазПревышОПС.Сум2Посл3М <= 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}