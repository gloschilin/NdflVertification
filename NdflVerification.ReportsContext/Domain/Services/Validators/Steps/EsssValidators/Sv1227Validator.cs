using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1227Validator : BaseReportStepValidator<Файл>
    {
        public Sv1227Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1227Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачислСВ.СумВсегоПер
                < entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВФарм.СумВсегоПер
                + entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВЧлЭС.СумВсегоПер
                + entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВПат.СумВсегоПер
                + entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВИнЛиц.СумВсегоПер)
            {
                return false;
            }
            return true;
        }
    }
}