using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1203Validator : BaseReportStepValidator<Файл>
    {
        public Sv1203Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1203Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.КолСтрахЛицВс.Кол3Посл3М.ToInt() > 0
                && entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.ВыплНачислФЛ.Сум3Посл3М <= 0)
            {
                return false;
            }
            return true;
        }
    }
}