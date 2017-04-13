using System;
using System.Collections.Generic;

namespace NdflVerification.ReportsContext.Domain.Services.Validators
{
    internal class TotalReportValidator : IReportValidator<Reports>
    {
        private readonly IReportValidator<Factories.XsdImplement.Esss.Файл> _esssValidator;
        private readonly IReportValidator<Factories.XsdImplement.Six.Файл> _ndflValidator;
        private readonly IEnumerable<IReportStepValidator<Reports>> _totalValidators;

        public TotalReportValidator(
            IReportValidator<Factories.XsdImplement.Esss.Файл> esssValidator,
            IReportValidator<Factories.XsdImplement.Six.Файл> ndflValidator,
            IEnumerable<IReportStepValidator<Reports>> totalValidators)
        {
            _esssValidator = esssValidator;
            _ndflValidator = ndflValidator;
            _totalValidators = totalValidators;
        }

        public void Validate(Reports report)
        {
            if (report.Esss != null)
            {
                _esssValidator.Validate(report.Esss);
            }

            if (report.Ndfl6 != null)
            {
                _ndflValidator.Validate(report.Ndfl6);
            }

            foreach (var reportStepValidator in _totalValidators)
            {
                reportStepValidator.Validate(report);
            }
        }

        public bool TryValidate(Reports report)
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