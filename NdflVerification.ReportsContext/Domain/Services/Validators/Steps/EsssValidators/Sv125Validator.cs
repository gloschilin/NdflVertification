using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv125Validator : BaseReportStepValidator<Файл>
    {
        public Sv125Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv125Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.УплСВПрев.Упл3Посл3М.Признак.ToInt()==1
                && entity.Документ.РасчетСВ.ОбязПлатСВ.УплПревОСС.УплПерОСС.СумСВУпл3М
                != entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.УплСВПрев.Упл3Посл3М.Сумма)
            {
                return false;
            }

            return true;
        }
    }
}