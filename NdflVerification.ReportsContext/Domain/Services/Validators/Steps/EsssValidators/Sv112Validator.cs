using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv112Validator : BaseReportStepValidator<Файл>
    {
        public Sv112Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv112Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.НачислСВ.Сум2Посл3М !=
                    entity.Документ.РасчетСВ.ОбязПлатСВ.УплПерОМС.СумСВУпл2М)
                {
                    return false;
                }
            }

            return true;
        }
    }
}