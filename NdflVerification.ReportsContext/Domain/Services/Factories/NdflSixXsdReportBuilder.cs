using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Six;

namespace NdflVerification.ReportsContext.Domain.Services.Factories
{
    /*
     * http://format.nalog.ru/
     * Получение необходимых XSD схем
     */

    /// <summary>
    /// Получение данные путем десериализации в объект из XSD схемы
    /// </summary>
    internal class NdflSixXsdReportBuilder: IXmlReportBuilder<SixNdfl>
    {
        public SixNdfl BuildFromXml(XDocument xmlDocument)
        {
            Файл xsdResult;

            var serializer = new XmlSerializer(typeof(Файл));

            using (var reader = new StringReader(xmlDocument.ToString()))
            {
                xsdResult = (Файл)serializer.Deserialize(reader);
            }

            var fiz = xsdResult.Документ.СвНП.Item as ФайлДокументСвНПНПФЛ;
            var ul = xsdResult.Документ.СвНП.Item as ФайлДокументСвНПНПЮЛ;
            var inn = fiz?.ИННФЛ ?? ul?.ИННЮЛ;
            var kpp = ul?.КПП;

            var notHoldTaxSum = GetDecimal(xsdResult.Документ.НДФЛ6.ОбобщПоказ.НеУдержНалИт);
            var employeeCount = int.Parse(xsdResult.Документ.НДФЛ6.ОбобщПоказ.КолФЛДоход);

            var document = new SixNdflDocument(xsdResult.Документ.КНД, xsdResult.Документ.Период,
                notHoldTaxSum, employeeCount);

            foreach (var rate in xsdResult.Документ.НДФЛ6.ОбобщПоказ.СумСтавка.Select(
                rateNode => new SumRate(rateNode.Ставка, rateNode.НачислДох, rateNode.НачислДохДив,
                GetDecimal(rateNode.ИсчислНал))))
            {
                document.SumRates.Add(rate);
            }

            var result = new SixNdfl(inn, kpp, xsdResult.Документ.ОтчетГод, document);

            return result;
        }

        private static decimal GetDecimal(string value)
        {
            return decimal.Parse(value,
                    new NumberFormatInfo() { NumberDecimalSeparator = "." });
        }
    }
}
