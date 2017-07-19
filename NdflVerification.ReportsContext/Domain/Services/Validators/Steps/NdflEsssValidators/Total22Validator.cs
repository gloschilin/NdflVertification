using System.Linq;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.NdflEsssValidators
{
    public class Total22Validator : BaseReportStepValidator<NdflEssReports>
    {
        public Total22Validator(IValidationResultHandler validationResultHandler, 
            IReportQuarterHelper<NdflEssReports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Total22Validator;
        public override bool IsSpecificatiedBy(NdflEssReports entity)
        {
            if (entity.Esss == null || entity.Ndfl == null)
            {
                return true;
            }

            return entity.Ndfl.Документ.НДФЛ6.ОбобщПоказ.СумСтавка.Sum(e => e.НачислДох)
                   - entity.Ndfl.Документ.НДФЛ6.ОбобщПоказ.СумСтавка.Sum(e => e.НачислДохДив)
                   >=
                   entity.Esss.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(
                       e => e.РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПер);
        }
    }
}