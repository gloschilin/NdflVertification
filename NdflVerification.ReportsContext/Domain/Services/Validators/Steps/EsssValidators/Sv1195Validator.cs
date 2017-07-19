using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1195Validator : BaseReportStepValidator<Файл>
    {
        public Sv1195Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1195Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {

            if (entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.КолСтрахЛицВс.КолВсегоПер.ToInt()
                < entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.КолСтрахЛицВс.КолВсегоПосл3М.ToInt())
            {
                return false;
            }
            return true;
        }
    }
}