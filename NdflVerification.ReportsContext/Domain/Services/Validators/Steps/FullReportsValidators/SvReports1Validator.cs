using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.FullReportsValidators
{
    /// <summary>
    /// Все отчёты одной компании. Проверяем по НПЮЛ ИННЮЛ="ХХХ" или НПИП ИННИП="ХХХ"
    /// </summary>
    public class SvReport2Validator: BaseReportStepValidator<Reports>
    {
        public SvReport2Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Reports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.SvReport2Validator;
        public override bool IsSpecificatiedBy(Reports entity)
        {
            var inn =
                GetInn(entity.Esss1) ?? GetInn(entity.Esss2) ?? GetInn(entity.Esss3) ?? GetInn(entity.Esss4)
                ??
                GetInn(entity.Ndfl61) ?? GetInn(entity.Ndfl62) ?? GetInn(entity.Ndfl63) ?? GetInn(entity.Ndfl64);

            return (string.IsNullOrEmpty(GetInn(entity.Esss1)) || GetInn(entity.Esss1) == inn)
                   && (string.IsNullOrEmpty(GetInn(entity.Esss2)) || GetInn(entity.Esss2) == inn)
                   && (string.IsNullOrEmpty(GetInn(entity.Esss3)) || GetInn(entity.Esss3) == inn)
                   && (string.IsNullOrEmpty(GetInn(entity.Esss4)) || GetInn(entity.Esss4) == inn)

                   && (string.IsNullOrEmpty(GetInn(entity.Ndfl61)) || GetInn(entity.Ndfl61) == inn)
                   && (string.IsNullOrEmpty(GetInn(entity.Ndfl62)) || GetInn(entity.Ndfl62) == inn)
                   && (string.IsNullOrEmpty(GetInn(entity.Ndfl63)) || GetInn(entity.Ndfl63) == inn)
                   && (string.IsNullOrEmpty(GetInn(entity.Ndfl64)) || GetInn(entity.Ndfl64) == inn);
        }

        private static string GetInn(Services.Factories.XsdImplement.Esss.Файл esss)
        {
            return (esss?.Документ.СвНП.Item as ФайлДокументСвНПНПИП)?.ИННФЛ
                   ?? (esss?.Документ.СвНП.Item as ФайлДокументСвНПНПФЛ)?.Item as string
                       ?? (esss?.Документ.СвНП.Item as ФайлДокументСвНПНПЮЛ)?.ИННЮЛ;
        }

        private static string GetInn(Services.Factories.XsdImplement.Six.Файл ndfl)
        {
            return (ndfl?.Документ.СвНП.Item as ФайлДокументСвНПНПИП)?.ИННФЛ
                   ?? (ndfl?.Документ.СвНП.Item as ФайлДокументСвНПНПФЛ)?.Item as string
                       ?? (ndfl?.Документ.СвНП.Item as ФайлДокументСвНПНПЮЛ)?.ИННЮЛ;
        }
    }

    /// <summary>
    /// Все загруженные отчёты — за один отчётный год. 
    /// Проверяем по Документ ОтчетГод=" ". Если нет, возвращаем ошибку.
    /// </summary>
    public class SvReports1Validator: BaseReportStepValidator<Reports>
    {
        public SvReports1Validator(IValidationResultHandler validationResultHandler, 
            IReportQuarterHelper<Reports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.SvReports1Validator;
        public override bool IsSpecificatiedBy(Reports entity)
        {
            var currentPeriod = entity.Esss1?.Документ.ОтчетГод
                                ?? entity.Esss2?.Документ.ОтчетГод
                                ?? entity.Esss3?.Документ.ОтчетГод
                                ?? entity.Esss4?.Документ.ОтчетГод
                                ?? entity.Ndfl61?.Документ.ОтчетГод
                                ?? entity.Ndfl62?.Документ.ОтчетГод
                                ?? entity.Ndfl63?.Документ.ОтчетГод
                                ?? entity.Ndfl64?.Документ.ОтчетГод;

            return (entity.Esss1 == null || entity.Esss1.Документ.ОтчетГод == currentPeriod)
                   && (entity.Esss2 == null || entity.Esss2.Документ.ОтчетГод == currentPeriod)
                   && (entity.Esss3 == null || entity.Esss3.Документ.ОтчетГод == currentPeriod)
                   && (entity.Esss4 == null || entity.Esss4.Документ.ОтчетГод == currentPeriod)
                   && (entity.Ndfl61 == null || entity.Ndfl61.Документ.ОтчетГод == currentPeriod)
                   && (entity.Ndfl62 == null || entity.Ndfl62.Документ.ОтчетГод == currentPeriod)
                   && (entity.Ndfl63 == null || entity.Ndfl63.Документ.ОтчетГод == currentPeriod)
                   && (entity.Ndfl64 == null || entity.Ndfl64.Документ.ОтчетГод == currentPeriod);

        }
    }
}
