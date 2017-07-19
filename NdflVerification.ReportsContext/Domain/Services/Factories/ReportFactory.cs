using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Factories
{
    public class Esss1ReprotFactory : EsssReprotFactory
    {
        public Esss1ReprotFactory(IXmlReportBuilder<Файл> xmlReportBuilder) : base(xmlReportBuilder)
        {
        }

        public override string PeriodValue => "21";
        public override ReportType ReportType => ReportType.Esss1;
    }

    public class Esss2ReprotFactory : EsssReprotFactory
    {
        public Esss2ReprotFactory(IXmlReportBuilder<Файл> xmlReportBuilder) : base(xmlReportBuilder)
        {
        }

        public override string PeriodValue => "31";
        public override ReportType ReportType => ReportType.Esss2;
    }

    public class Esss3ReprotFactory : EsssReprotFactory
    {
        public Esss3ReprotFactory(IXmlReportBuilder<Файл> xmlReportBuilder) : base(xmlReportBuilder)
        {
        }

        public override string PeriodValue => "23";
        public override ReportType ReportType => ReportType.Esss3;
    }

    public class Esss4ReprotFactory : EsssReprotFactory
    {
        public Esss4ReprotFactory(IXmlReportBuilder<Файл> xmlReportBuilder) : base(xmlReportBuilder)
        {
        }

        public override string PeriodValue => "34";
        public override ReportType ReportType => ReportType.Esss4;
    }

    public abstract class EsssReprotFactory: ReportFactory<XsdImplement.Esss.Файл>
    {
        protected EsssReprotFactory(IXmlReportBuilder<XsdImplement.Esss.Файл> xmlReportBuilder) 
            : base(xmlReportBuilder)
        {
        }

        public override bool Allow(XDocument xmlDocument)
        {
            return xmlDocument.Descendants().Any(e => e.Name == "РасчетСВ")
                && xmlDocument.Descendants().First(e=>e.Name == "Документ")?.Attribute("Период")?.Value == PeriodValue;
        }

        public abstract string PeriodValue { get; }
    }

    public abstract class Ndfl6ReprotFactory : ReportFactory<XsdImplement.Six.Файл>
    {
        protected Ndfl6ReprotFactory(IXmlReportBuilder<XsdImplement.Six.Файл> xmlReportBuilder) 
            : base(xmlReportBuilder)
        {
        }

        public override bool Allow(XDocument xmlDocument)
        {
            return xmlDocument.Descendants().Any(e => e.Name == "НДФЛ6")
                && xmlDocument.Descendants().First(e => e.Name == "Документ")?.Attribute("Период")?.Value == PeriodValue; 
        }

        protected abstract string PeriodValue { get; }
    }

    public class Ndfl61ReportFactory: Ndfl6ReprotFactory
    {
        public Ndfl61ReportFactory(IXmlReportBuilder<XsdImplement.Six.Файл> xmlReportBuilder) : base(xmlReportBuilder)
        {
        }

        public override ReportType ReportType => ReportType.SixNdfl1;
        protected override string PeriodValue => "21";
    }

    public class Ndfl62ReportFactory : Ndfl6ReprotFactory
    {
        public Ndfl62ReportFactory(IXmlReportBuilder<XsdImplement.Six.Файл> xmlReportBuilder) : base(xmlReportBuilder)
        {
        }

        public override ReportType ReportType => ReportType.SixNdfl2;
        protected override string PeriodValue => "31";
    }

    public class Ndfl63ReportFactory : Ndfl6ReprotFactory
    {
        public Ndfl63ReportFactory(IXmlReportBuilder<XsdImplement.Six.Файл> xmlReportBuilder) : base(xmlReportBuilder)
        {
        }

        public override ReportType ReportType => ReportType.SixNdfl3;
        protected override string PeriodValue => "23";
    }

    public class Ndfl64ReportFactory : Ndfl6ReprotFactory
    {
        public Ndfl64ReportFactory(IXmlReportBuilder<XsdImplement.Six.Файл> xmlReportBuilder) : base(xmlReportBuilder)
        {
        }

        public override ReportType ReportType => ReportType.SixNdfl4;
        protected override string PeriodValue => "34";
    }

    public abstract class ReportFactory<TReport>: IReportFactory<TReport>
        where TReport: class
    {
        private readonly IXmlReportBuilder<TReport> _xmlReportBuilder;

        protected ReportFactory(IXmlReportBuilder<TReport> xmlReportBuilder)
        {
            _xmlReportBuilder = xmlReportBuilder;
        }

        public abstract bool Allow(XDocument xmlDocument);
        
        public bool Allow(string pathToFile)
        {
            if (!File.Exists(pathToFile))
            {
                throw new FileNotFoundException(
                    $"Загруженный файл запрошенного отчета не найден {pathToFile}", pathToFile);
            }

            var fileContent = File.ReadAllText(pathToFile, GetEncoding());

            var xmlDocumnet = XDocument.Parse(fileContent);

            return Allow(xmlDocumnet);
        }

        public TReport ReadFromStream(Stream stream)
        {
            string streamContent;

            using (var streamReader = new StreamReader(stream, GetEncoding()))
            {
                streamContent = streamReader.ReadToEnd();
            }

            //TODO: handle exception
            var xmlDocumnet = XDocument.Parse(streamContent);

            return ReadFromXml(xmlDocumnet);
        }

        public TReport ReadFromXml(XDocument xmlDocument)
        {
            var report = _xmlReportBuilder.BuildFromXml(xmlDocument);
            return report;
        }
        
        public TReport ReadFromLocalFile(string pathToFile)
        {
            if (!File.Exists(pathToFile))
            {
                throw new FileNotFoundException(
                    $"Загруженный файл запрошенного отчета не найден {pathToFile}", pathToFile);
            }

            var fileContent = File.ReadAllText(pathToFile, GetEncoding());

            var xmlDocumnet = XDocument.Parse(fileContent);

            return ReadFromXml(xmlDocumnet);
        }

        public bool TryReadFromLocalFile(string pathToFile, out TReport report)
        {
            report = null;
            try
            {
                report = ReadFromLocalFile(pathToFile);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static Encoding GetEncoding()
        {
            return Encoding.GetEncoding("windows-1251");
        }

        public abstract ReportType ReportType { get; }
    }
}