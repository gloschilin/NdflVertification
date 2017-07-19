using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv147Validator : BaseReportStepValidator<Файл>
    {
        public Sv147Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv147Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолЛицНачСВВс.КолВсегоПосл3М.ToInt() > 0
                    && файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПосл3М <= 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}