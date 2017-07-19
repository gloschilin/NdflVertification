using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv129Validator : BaseReportStepValidator<Файл>
    {
        public Sv129Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv129Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.УплСВПрев.Упл3Посл3М.Признак.ToInt() == 2
                &&
                entity.Документ.РасчетСВ.ОбязПлатСВ.УплПревОСС.ПревРасхОСС.ПревРасхСВ3М
                != entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.УплСВПрев.Упл3Посл3М.Сумма)
            {
                return false;
            }

            return true;
        }
    }
}