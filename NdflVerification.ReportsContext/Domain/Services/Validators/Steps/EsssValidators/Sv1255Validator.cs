using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    

    public class Sv1255Validator : BaseReportStepValidator<Файл>
    {
        public Sv1255Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1255Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (entity.Документ.РасчетСВ.ОбязПлатСВ.ПравТариф51427.Дох34615Вс.ToInt() <
                entity.Документ.РасчетСВ.ОбязПлатСВ.ПравТариф51427.Дох6427.ToInt())
            {
                return false;
            }
            return true;
        }
    }
}