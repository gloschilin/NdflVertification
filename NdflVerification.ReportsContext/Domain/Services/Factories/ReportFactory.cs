using System.IO;
using System.Text;
using System.Xml.Linq;

namespace NdflVerification.ReportsContext.Domain.Services.Factories
{
    internal class ReportFactory<TReport>: IReportFactory<TReport>
    {
        private readonly IXmlReportBuilder<TReport> _xmlReportBuilder;
        public ReportFactory(IXmlReportBuilder<TReport> xmlReportBuilder)
        {
            _xmlReportBuilder = xmlReportBuilder;
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

            //TODO: handle exception
            var xmlDocumnet = XDocument.Parse(fileContent);

            return ReadFromXml(xmlDocumnet);
        }

        private static Encoding GetEncoding()
        {
            return Encoding.GetEncoding("windows-1251");
        }
    }
}