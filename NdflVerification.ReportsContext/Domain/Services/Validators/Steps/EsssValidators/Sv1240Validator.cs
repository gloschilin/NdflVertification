using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1240Validator : BaseReportStepValidator<Файл>
    {
        public Sv1240Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1240Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (!AllEquals(entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВИнЛиц.СумВсегоПосл3М,
                entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВИнЛиц.Сум1Посл3М
                + entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВИнЛиц.Сум2Посл3М
                + entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.БазНачСВИнЛиц.Сум3Посл3М))
            {
                return false;
            }
            return true;
        }
    }
}