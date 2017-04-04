using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv111Validator : BaseReportStepValidator<Файл>
    {
        public Sv111Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv111Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.НачислСВ.Сум1Посл3М !=
                    entity.Документ.РасчетСВ.ОбязПлатСВ.УплПерОМС.СумСВУпл1М)
                {
                    return false;
                }
            }

            return true;
        }
    }
}