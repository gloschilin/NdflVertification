﻿using System.Linq;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv17Validator : BaseReportStepValidator<Файл>
    {
        public Sv17Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv17Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (entity.Документ.РасчетСВ.ОбязПлатСВ.УплПерОПС.СумСВУпл1М !=
                entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(e => e.РасчСВ_ОПС.НачислСВ.Сум1Посл3М))
            {
                return false;
            }


            return true;
        }
    }
}