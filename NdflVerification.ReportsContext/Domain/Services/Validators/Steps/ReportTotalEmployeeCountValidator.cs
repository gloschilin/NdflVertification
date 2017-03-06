using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps
{
    /// <summary>
    /// Количество ребят, получивших доход.
    /// </summary>
    internal class ReportTotalEmployeeCountValidator : BaseReportStepValidator<Reports>
    {
        public ReportTotalEmployeeCountValidator(IValidationResultHandler validationResultHandler)
            : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.ReportsTotalEmployeeCount;

        public override bool IsSpecificatiedBy(Reports entity)
        {
            return entity.SixNdfl.GetTotalEmployeeCount() == entity.TwoNdfl.GetTotalEmployeeCount();
        }
    }
}