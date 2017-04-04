using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1211Validator : BaseReportStepValidator<Файл>
    {
        public Sv1211Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1211Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.ВыплНачислФЛ.СумВсегоПер
                < entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазПревышСВ.СумВсегоПер)
            {
                return false;
            }
            return true;
        }
    }
}