using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    //public class Sv1256Validator : BaseReportStepValidator<Файл>
    //{
    //    public Sv1256Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
    //    {
    //    }

    //    protected override CheckReportType CheckReportType => CheckReportType.Sv1256Validator;

    //    public override bool IsSpecificatiedBy(Файл entity)
    //    {
    //        if (
    //            entity.Документ.РасчетСВ.ОбязПлатСВ.ПравТариф51427.Дох34615Вс.ToInt() != 0 
    //            &&
    //            !AllEquals(entity.Документ.РасчетСВ.ОбязПлатСВ.ПравТариф51427.ДолДох6427,
    //            entity.Документ.РасчетСВ.ОбязПлатСВ.ПравТариф51427.Дох6427.ToInt() 
    //            / entity.Документ.РасчетСВ.ОбязПлатСВ.ПравТариф51427.Дох34615Вс.ToInt() 
    //            * 100))
    //        {
    //            return false;
    //        }
    //        return true;
    //    }
    //}
}