using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv175Validator : BaseReportStepValidator<Файл>
    {
        public Sv175Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv175Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазНачислСВ.СумВсегоПер <
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазПревышОПС.СумВсегоПер)
                {
                    return false;
                }
            }
            return true;
        }
    }
}