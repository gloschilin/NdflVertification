using System;
using System.Collections.Generic;

namespace NdflVerification.ReportsContext.Domain.Services.Validators
{
    internal class ReportValidator<TReport> : IReportValidator<TReport>
    {
        private readonly IEnumerable<IReportStepValidator<TReport>> _stepValidators;

        public ReportValidator(IEnumerable<IReportStepValidator<TReport>>  stepValidators)
        {
            _stepValidators = stepValidators;
        }

        public void Validate(TReport report)
        {
            foreach (var stepValidator in _stepValidators)
            {
                stepValidator.Validate(report);
            }
        }

        public bool TryValidate(TReport report)
        {
            try
            {
                Validate(report);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}