using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1215Validator : BaseReportStepValidator<Файл>
    {
        public Sv1215Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1215Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.ВыплНачислФЛ.Сум3Посл3М
                < entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачислСВ.Сум3Посл3М)
            {
                return false;
            }
            return true;
        }
    }
}