using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1214Validator : BaseReportStepValidator<Файл>
    {
        public Sv1214Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1214Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.ВыплНачислФЛ.Сум2Посл3М
                < entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазПревышСВ.Сум2Посл3М)
            {
                return false;
            }
            return true;
        }
    }
}