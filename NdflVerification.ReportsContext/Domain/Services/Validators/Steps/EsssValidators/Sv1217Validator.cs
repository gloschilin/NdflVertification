using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1217Validator : BaseReportStepValidator<Файл>
    {
        public Sv1217Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1217Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (!AllEquals(
                entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.НеОбложенСВ.СумВсегоПер,
                0
                + entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.НеОбложенСВ.СумВсегоПосл3М
                ))
            {
                return false;
            }
            return true;
        }
    }
}