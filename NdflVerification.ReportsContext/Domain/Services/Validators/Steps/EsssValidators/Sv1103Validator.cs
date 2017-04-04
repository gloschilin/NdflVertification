﻿using System;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1103Validator : BaseReportStepValidator<Файл>
    {
        public Sv1103Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1103Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            throw new NotImplementedException();
        }
    }
}