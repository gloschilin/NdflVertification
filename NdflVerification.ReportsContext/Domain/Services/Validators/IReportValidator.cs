namespace NdflVerification.ReportsContext.Domain.Services.Validators
{
    /// <summary>
    /// Первичный валидатор отчетности
    /// </summary>
    public interface IReportValidator<in TReport>
    {
        /// <summary>
        /// Валидировать отчет
        /// </summary>
        /// <param name="report"></param>
        void Validate(TReport report);
    }
}
