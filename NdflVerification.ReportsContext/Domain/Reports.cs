
using System;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;
using Файл = NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Six.Файл;

namespace NdflVerification.ReportsContext.Domain
{
    /// <summary>
    /// Отчеты 6 НДФЛ и ЕССС
    /// </summary>
    public class Reports
    {
        public Services.Factories.XsdImplement.Esss.Файл Esss1 { get; set; }
        public Services.Factories.XsdImplement.Esss.Файл Esss2 { get; set; }
        public Services.Factories.XsdImplement.Esss.Файл Esss3 { get; set; }
        public Services.Factories.XsdImplement.Esss.Файл Esss4 { get; set; }
        public Services.Factories.XsdImplement.Six.Файл Ndfl61 { get; set; }
        public Services.Factories.XsdImplement.Six.Файл Ndfl62 { get; set; }
        public Services.Factories.XsdImplement.Six.Файл Ndfl63 { get; set; }
        public Services.Factories.XsdImplement.Six.Файл Ndfl64 { get; set; }

        public void SetNdfl(Файл file, ReportType type)
        {
            switch (type)
            {
                case ReportType.SixNdfl1:
                    Ndfl61 = file;
                    break;
                case ReportType.SixNdfl2:
                    Ndfl62 = file;
                    break;
                case ReportType.SixNdfl3:
                    Ndfl63 = file;
                    break;
                case ReportType.SixNdfl4:
                    Ndfl64 = file;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public void SetEsss(Services.Factories.XsdImplement.Esss.Файл file, ReportType type)
        {
            switch (type)
            {
                case ReportType.Esss1:
                    Esss1 = file;
                    break;
                case ReportType.Esss2:
                    Esss2 = file;
                    break;
                case ReportType.Esss3:
                    Esss3 = file;
                    break;
                case ReportType.Esss4:
                    Esss4 = file;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }

    public class EsssReports
    {
        public Services.Factories.XsdImplement.Esss.Файл Previous { get; set; }
        public Services.Factories.XsdImplement.Esss.Файл Current { get; set; }
    }

    public class NdflEssReports
    {
        public Services.Factories.XsdImplement.Esss.Файл Esss { get; set; }
        public Services.Factories.XsdImplement.Six.Файл Ndfl { get; set; }
    }
}
