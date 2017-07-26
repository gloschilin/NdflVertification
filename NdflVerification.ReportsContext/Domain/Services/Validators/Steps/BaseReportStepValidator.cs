using System;
using System.Linq;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;
using NdflVerification.ReportsContext.Utils;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps
{
    public abstract class BaseEsssValidator : BaseReportStepValidator<Файл>
    {
        private readonly IReportQuarterHelper<Файл> _reportQuarterHelper;

        protected BaseEsssValidator(IValidationResultHandler validationResultHandler, 
            IReportQuarterHelper<Файл> reportQuarterHelper) 
            : base(validationResultHandler, reportQuarterHelper)
        {
            _reportQuarterHelper = reportQuarterHelper;
        }

        public int GetStartMonth(Файл entity)
        {
            var quarter = _reportQuarterHelper.GetQuarter(entity);
            switch (quarter)
            {
                case 1:
                    return 1;
                case 2:
                    return 4;
                case 3:
                    return 7;
                case 4:
                    return 10;
                default:
                    throw  new ApplicationException("Неизвестный тип квартала");
            }
        }
        
    }

    public interface IReportQuarterHelper<in TReport>
    {
        int GetQuarter(TReport report);
    }

    /// <summary>
    /// Базовый класс валидатора
    /// </summary>
    /// <typeparam name="TReport"></typeparam>
    public abstract class BaseReportStepValidator<TReport>: 
        IReportStepValidator<TReport>, ISpecification<TReport>
    {
        private readonly IValidationResultHandler _validationResultHandler;
        private readonly IReportQuarterHelper<TReport> _reportQuarterHelper;

        protected BaseReportStepValidator(IValidationResultHandler validationResultHandler, 
            IReportQuarterHelper<TReport> reportQuarterHelper)
        {
            _validationResultHandler = validationResultHandler;
            _reportQuarterHelper = reportQuarterHelper;
        }

        public int GetQuarter(TReport report)
        {
            return _reportQuarterHelper.GetQuarter(report);
        }

        public int GetQuarterStartMonth(TReport report)
        {
            var quarter = GetQuarter(report);
            return quarter*3 - 2;
        }

        public void Validate(TReport report)
        {
            var specificationResult = IsSpecificatiedBy(report);

            var validationResult = new ValidationResult
            {
                ValidationResultType = specificationResult
                    ? ValidationResultType.Success
                    : ValidationResultType.Error,
                СheckReportType = CheckReportType,
                Quarter = _reportQuarterHelper.GetQuarter(report)
            };

            _validationResultHandler.Handle(validationResult);
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
            if (paramseters.All(e => e == null))
            {
                return true;
            }

            var first = paramseters.First();
            var result = paramseters.All(e => e != null && e.Equals(first));
            return result;
        }
    }
}