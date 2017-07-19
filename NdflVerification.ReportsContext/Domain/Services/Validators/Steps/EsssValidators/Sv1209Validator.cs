﻿using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1209Validator : BaseReportStepValidator<Файл>
    {
        public Sv1209Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1209Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.ВыплНачислФЛ.Сум2Посл3М
                < entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.НеОбложенСВ.Сум2Посл3М)
            {
                return false;
            }
            return true;
        }
    }
}