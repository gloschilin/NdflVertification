using System;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps
{
    public class EsssQuarterHelper: IReportQuarterHelper<Файл>
    {
        public int GetQuarter(Файл report)
        {
            var textVersion = report.Документ.Период;
            switch (textVersion)
            {
                case "21":
                    return 1;
                case "31":
                    return 2;
                case "33":
                    return 3;
                case "34":
                    return 4;
                default:
                    throw new ApplicationException($"Неизвестный период отчета {textVersion}");
            }
        }
    }

    public class TotalReportsQuarterHelper: IReportQuarterHelper<Reports>
    {
        public int GetQuarter(Reports report)
        {
            return 4;
        }
    }

    public class NdflEssReportsQuarterHelper: IReportQuarterHelper<NdflEssReports>
    {
        private readonly IReportQuarterHelper<Файл> _esssReportQuarterHelper;

        public NdflEssReportsQuarterHelper(IReportQuarterHelper<Файл> esssReportQuarterHelper)
        {
            _esssReportQuarterHelper = esssReportQuarterHelper;
        }

        public int GetQuarter(NdflEssReports report)
        {
            return _esssReportQuarterHelper.GetQuarter(report.Esss);
        }
    }

    public class EsssQuartersQuarterHelper : IReportQuarterHelper<EsssReports>
    {
        public int GetQuarter(EsssReports report)
        {
            var textVersion = report.Current.Документ.Период;
            switch (textVersion)
            {
                case "21":
                    return 1;
                case "31":
                    return 2;
                case "33":
                    return 3;
                case "34":
                    return 4;
                default:
                    throw new ApplicationException($"Неизвестный период отчета {textVersion}");
            }
        }
    }

    public class SixNdflQuarterHelper: IReportQuarterHelper<Factories.XsdImplement.Six.Файл>
    {
        public int GetQuarter(Factories.XsdImplement.Six.Файл report)
        {
            var textVersion = report.Документ.Период;
            switch (textVersion)
            {
                case "21":
                    return 1;
                case "31":
                    return 2;
                case "33":
                    return 3;
                case "34":
                    return 4;
                default:
                    throw new ApplicationException($"Неизвестный период отчета {textVersion}");
            }
        }
    }
}