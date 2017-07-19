using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv126Validator : BaseReportStepValidator<Файл>
    {
        public Sv126Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv126Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.УплСВПрев.УплВсегоПер.Признак.ToInt() == 2
                && entity.Документ.РасчетСВ.ОбязПлатСВ.УплПревОСС.ПревРасхОСС.ПревРасхСВПер
                != entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.УплСВПрев.УплВсегоПер.Сумма)
            {
                return false;
            }

            return true;
        }
    }
}