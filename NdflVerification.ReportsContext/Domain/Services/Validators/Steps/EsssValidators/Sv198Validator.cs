using System;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv198Validator : BaseReportStepValidator<Файл>
    {
        public Sv198Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv198Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            throw  new NotImplementedException();
        }
    }
}