using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1101Validator : BaseReportStepValidator<Файл>
    {
        public Sv1101Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1101Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.КолСтрахЛицВс.КолВсегоПосл3М.ToInt() <
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.КолСтрахЛицВс.Кол2Посл3М.ToInt())
                {
                    return false;
                }
            }
            return true;
        }
    }
}