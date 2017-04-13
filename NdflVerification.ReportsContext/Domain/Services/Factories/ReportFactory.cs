using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace NdflVerification.ReportsContext.Domain.Services.Factories
{

    public class EsssReprotFactory: ReportFactory<XsdImplement.Esss.Файл>
    {
        public EsssReprotFactory(IXmlReportBuilder<XsdImplement.Esss.Файл> xmlReportBuilder) : base(xmlReportBuilder)
        {
        }

        public override bool Allow(XDocument xmlDocument)
        {
            return xmlDocument.Descendants().Any(e => e.Name == "РасчетСВ");
        }
    }

    public class Ndfl6ReprotFactory : ReportFactory<XsdImplement.Six.Файл>
    {
        public Ndfl6ReprotFactory(IXmlReportBuilder<XsdImplement.Six.Файл> xmlReportBuilder) : base(xmlReportBuilder)
        {
        }

        public override bool Allow(XDocument xmlDocument)
        {
            return xmlDocument.Descendants().Any(e => e.Name == "НДФЛ6");
        }
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
    }
}