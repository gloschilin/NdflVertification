using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;

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

    public class XmlEsssBuilder: IXmlReportBuilder<Файл>
    {
        public Файл BuildFromXml(XDocument xmlDocument)
        {
            var serializer = new XmlSerializer(typeof(XsdImplement.Six.Файл));

            using (var reader = new StringReader(xmlDocument.ToString()))
            {
                var xsdResult = (Файл)serializer.Deserialize(reader);
                return xsdResult;
            }
        }
    }
}