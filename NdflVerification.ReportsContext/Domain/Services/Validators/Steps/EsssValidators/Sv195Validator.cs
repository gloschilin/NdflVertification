using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv195Validator : BaseReportStepValidator<Файл>
    {
        public Sv195Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv195Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.КолСтрахЛицВс.Кол1Посл3М.ToInt() <
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.КолЛицНачСВВс.Кол1Посл3М.ToInt())
                {
                    return false;
                }
            }
            return true;
        }
    }
}