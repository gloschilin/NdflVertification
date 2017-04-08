using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv127Validator : BaseReportStepValidator<Файл>
    {
        public Sv127Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv127Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.УплСВПрев.Упл1Посл3М.Признак.ToInt() == 2
                &&
                entity.Документ.РасчетСВ.ОбязПлатСВ.УплПревОСС.ПревРасхОСС.ПревРасхСВ1М
                != entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.УплСВПрев.Упл1Посл3М.Сумма)
            {
                return false;
            }

            return true;
        }
    }
}