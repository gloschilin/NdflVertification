using System.Linq;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.Total
{
    public class Total22Validator : BaseReportStepValidator<Reports>
    {
        public Total22Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Total22Validator;
        public override bool IsSpecificatiedBy(Reports entity)
        {
            if (entity.Esss == null || entity.Ndfl6 == null)
            {
                return true;
            }

            return entity.Ndfl6.Документ.НДФЛ6.ОбобщПоказ.СумСтавка.Sum(e => e.НачислДох)
                   - entity.Ndfl6.Документ.НДФЛ6.ОбобщПоказ.СумСтавка.Sum(e => e.НачислДохДив)
                   >=
                   entity.Esss.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(
                       e => e.РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПер);
        }
    }
}