using System;
using System.Linq;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;
using NdflVerification.ReportsContext.Extensions;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv10Validator : BaseReportStepValidator<Файл>
    {
        /// <summary>
        /// Возможное нарушение срока представления первичного Расчета
        /// </summary>
        /// <param name="validationResultHandler"></param>
        public Sv10Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv10Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (entity.Документ.ДатаДок.ToDateTime() <= GetMaxDate())
            {
                return false;
            }

            return true;
        }

        private static DateTime GetMaxDate()
        {
            return DateTime.Now;
        }
    }
}
