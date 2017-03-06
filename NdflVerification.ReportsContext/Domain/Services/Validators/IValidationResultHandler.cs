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
        /// <param name="checkReportType"></param>
        /// <param name="validationResultType"></param>
        void Handle(CheckReportType checkReportType, ValidationResultType validationResultType);
    }
}