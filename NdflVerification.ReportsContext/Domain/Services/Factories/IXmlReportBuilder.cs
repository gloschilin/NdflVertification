using System.Xml.Linq;

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
}