using System;
using System.Linq;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;
using NdflVerification.ReportsContext.Utils;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps
{
    /// <summary>
    /// Базовый класс валидатора
    /// </summary>
    /// <typeparam name="TReport"></typeparam>
    public abstract class BaseReportStepValidator<TReport>: 
        IReportStepValidator<TReport>, ISpecification<TReport>
    {
        private readonly IValidationResultHandler _validationResultHandler;

        protected BaseReportStepValidator(IValidationResultHandler validationResultHandler)
        {
            _validationResultHandler = validationResultHandler;
        }

        public void Validate(TReport report)
        {
            var specificationResult = IsSpecificatiedBy(report);
            _validationResultHandler.Handle(CheckReportType, 
                specificationResult 
                    ? ValidationResultType.Success
                    : ValidationResultType.Error);
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

        /// <summary>
        /// Тип проверки
        /// </summary>
        protected abstract CheckReportType CheckReportType { get; }

        /// <summary>
        /// Проверка удовлетворения условию
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract bool IsSpecificatiedBy(TReport entity);

        protected static bool AllEquals<T>(params T[] paramseters)
        {
            var first = paramseters.First();
            var result = paramseters.All(e => e != null && e.Equals(first));
            return result;
        }
    }
}