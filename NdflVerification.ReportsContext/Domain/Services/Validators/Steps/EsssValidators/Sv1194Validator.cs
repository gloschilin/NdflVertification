﻿using System;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1194Validator : BaseReportStepValidator<Файл>
    {
        public Sv1194Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1194Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {

            if (entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОССВНМ.КолСтрахЛицВс.КолВсегоПер.ToInt() < 0)
            {
                return false;
            }
            return true;
        }
    }
}