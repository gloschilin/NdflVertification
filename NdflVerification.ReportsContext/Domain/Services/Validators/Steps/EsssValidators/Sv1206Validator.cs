using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1206Validator : BaseReportStepValidator<Файл>
    {
        public Sv1206Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1206Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.ВыплНачислФЛ.СумВсегоПер
                < entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.НеОбложенСВ.СумВсегоПер)
            {
                return false;
            }
            return true;
        }
    }
}