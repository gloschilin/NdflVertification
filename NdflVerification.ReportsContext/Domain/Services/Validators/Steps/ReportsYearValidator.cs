using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps
{
    /// <summary>
    ///  Проверка по дате.
    /// </summary>
    internal class ReportsYearValidator: BaseReportStepValidator<Reports>
    {
        private readonly TwoNdflYearValidator _twoNdflYearValidator;

        public ReportsYearValidator(IValidationResultHandler validationResultHandler, 
            TwoNdflYearValidator twoNdflYearValidator) 
            : base(validationResultHandler)
        {
            _twoNdflYearValidator = twoNdflYearValidator;
        }

        protected override CheckReportType CheckReportType => CheckReportType.ReportsYear;

        public override bool IsSpecificatiedBy(Reports entity)
        {
            return _twoNdflYearValidator.IsSpecificatiedBy(entity.TwoNdfl)
                   && entity.SixNdfl.ReportYear == entity.TwoNdfl.ReportYear;
        }
    }
}