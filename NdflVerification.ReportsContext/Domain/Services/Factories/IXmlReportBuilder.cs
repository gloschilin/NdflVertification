using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace NdflVerification.ReportsContext.Domain.Services.Factories
{
    /// <summary>
    /// Сборка отчета из XML
    /// </summary>
    /// <typeparam name="TReport"></typeparam>
    public interface IXmlReportBuilder<out TReport>
    {
        /// <summary>
        /// Получить агрегат отчета из XML
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <returns></returns>
        TReport BuildFromXml(XDocument xmlDocument);
    }

    public class ReportBuilder<TFile>: IXmlReportBuilder<TFile>
    {
        public TFile BuildFromXml(XDocument xmlDocument)
        {
            var serializer = new XmlSerializer(typeof(TFile));

            using (var reader = new StringReader(xmlDocument.ToString()))
            {
                var xsdResult = (TFile)serializer.Deserialize(reader);
                return xsdResult;
            }
        }
    }
}