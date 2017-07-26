using System;
using System.Collections.Generic;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;

namespace NdflVerification.ReportsContext.Domain.Services.Validators
{
    public interface IReportResultValidator : IReportValidator<Reports>
    {

    }

    internal class TotalReportValidator : IReportResultValidator
    {
        private readonly IReportValidator<Factories.XsdImplement.Esss.Файл> _esssValidator;
        private readonly IReportValidator<Factories.XsdImplement.Six.Файл> _ndflValidator;
        private readonly IReportValidator<Reports> _totalValidator;
        private readonly IReportValidator<EsssReports> _esssReportsValidators;
        private readonly IReportValidator<NdflEssReports> _essNdflValidators;
        private readonly IValidationResultHandler _validationResultHandler;

        public TotalReportValidator(IReportValidator<Файл> esssValidator, 
            IReportValidator<Factories.XsdImplement.Six.Файл> ndflValidator, 
            IReportValidator<Reports> totalValidator, 
            IReportValidator<EsssReports> esssReportsValidators, 
            IReportValidator<NdflEssReports> essNdflValidators,
            IValidationResultHandler validationResultHandler)
        {
            _esssValidator = esssValidator;
            _ndflValidator = ndflValidator;
            _totalValidator = totalValidator;
            _esssReportsValidators = esssReportsValidators;
            _essNdflValidators = essNdflValidators;
            _validationResultHandler = validationResultHandler;
        }

        private void ValidateEsss(Reports report)
        {
            if (report.Esss1 != null)
            {
                _esssValidator.Validate(report.Esss1);
            }

            if (report.Esss2 != null)
            {
                _esssValidator.Validate(report.Esss2);
            }

            if (report.Esss3 != null)
            {
                _esssValidator.Validate(report.Esss3);
            }

            if (report.Esss4 != null)
            {
                _esssValidator.Validate(report.Esss4);
            }
        }

        private void ValidateNdfl(Reports report)
        {
            if (report.Ndfl61 != null)
            {
                _ndflValidator.Validate(report.Ndfl61);
            }

            if (report.Ndfl62 != null)
            {
                _ndflValidator.Validate(report.Ndfl62);
            }

            if (report.Ndfl63 != null)
            {
                _ndflValidator.Validate(report.Ndfl63);
            }

            if (report.Ndfl64 != null)
            {
                _ndflValidator.Validate(report.Ndfl64);
            }
        }

        private void ValidateEsssQuarters(Reports report)
        {
            if (report.Esss1 != null)
            {
                _esssReportsValidators.Validate(new EsssReports { Current = report.Esss1 });
            }

            if (report.Esss1 != null && report.Esss2 != null)
            {
                _esssReportsValidators.Validate(new EsssReports { Current = report.Esss2, Previous = report.Esss1 });
            }

            if (report.Esss2 != null && report.Esss3 != null)
            {
                _esssReportsValidators.Validate(new EsssReports { Current = report.Esss3, Previous = report.Esss2 });
            }

            if (report.Esss3 != null && report.Esss4 != null)
            {
                _esssReportsValidators.Validate(new EsssReports { Current = report.Esss4, Previous = report.Esss3 });
            }
        }

        private void ValidateEsssAndNdfl(Reports report)
        {
            _essNdflValidators.Validate(new NdflEssReports { Ndfl = report.Ndfl61, Esss = report.Esss1 });
            _essNdflValidators.Validate(new NdflEssReports { Ndfl = report.Ndfl62, Esss = report.Esss2 });
            _essNdflValidators.Validate(new NdflEssReports { Ndfl = report.Ndfl63, Esss = report.Esss3 });
            _essNdflValidators.Validate(new NdflEssReports { Ndfl = report.Ndfl64, Esss = report.Esss4 });
        }

        public void Validate(Reports report)
        {
            _totalValidator.Validate(report);
            if (_validationResultHandler.AnyErrors())
            {
                return;
            }
            
            ValidateEsssAndNdfl(report);

            if (_validationResultHandler.AnyErrors())
            {
                return;
            }

            ValidateEsss(report);
            ValidateNdfl(report);
            ValidateEsssQuarters(report);
            
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