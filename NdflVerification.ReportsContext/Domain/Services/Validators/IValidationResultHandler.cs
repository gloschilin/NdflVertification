using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;
using NdflVerification.ReportsContext.Domain.Services.Validators.Steps;

namespace NdflVerification.ReportsContext.Domain.Services.Validators
{
    /// <summary>
    /// Обработчик результат валидации
    /// </summary>
    public interface IValidationResultHandler
    {
        /// <summary>
        /// Обработать результат валидации
        /// </summary>
        void Handle(ValidationResult validationResult);
    }

    public class ValidationResult
    {
        public CheckReportType СheckReportType { get; set; }
        public ValidationResultType ValidationResultType { get; set; }
        public int Quarter { get; set; }
    }
}