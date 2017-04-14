using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv153Validator : BaseReportStepValidator<Файл>
    {
        public Sv153Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv153Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ПревБазОПС.КолВсегоПосл3М.ToInt()
                    < файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ПревБазОПС.Кол1Посл3М.ToInt())

                {
                    return false;
                }
            }

            return true;
        }
    }
}