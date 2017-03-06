namespace NdflVerification.ReportsContext.Domain.Services.Validators
{
    /// <summary>
    /// Первичный валидатор отчета конкретного параметра
    /// </summary>
    /// <typeparam name="TReport"></typeparam>
    public interface IReportStepValidator<in TReport> : IReportValidator<TReport>
    {

    }
}