using System;
using System.Linq;
using System.Xml.Linq;
using NdflVerification.ReportsContext.Utils;

namespace NdflVerification.ReportsContext.Domain.Services.Factories
{
    /// <summary>
    /// Сборщик модели 6НДФЛ из XML
    /// </summary>
    internal class NdflSixXmlReportBuilder : IXmlReportBuilder<SixNdfl>
    {
        public SixNdfl BuildFromXml(XDocument xmlDocument)
        {
            string inn, kpp;
            
            var fileNode = xmlDocument.GetRootNode("Файл");
            var documentNode = fileNode.GetChildNode("Документ");
            var reportYear = documentNode.GetAttributeValue("ОтчетГод");

            var svNpNode = documentNode.GetChildNode("СвНП");

            XElement np;
            if (svNpNode.TryGetChildNode("НПЮЛ", out np))
            {
                inn = np.GetAttributeValue("ИННЮЛ");
                kpp = np.GetAttributeValue("КПП");
            }
            else
            {
                throw new NotImplementedException("Нет обработки для физ лица");
            }

            var commonViewNode = documentNode.GetChildNode("НДФЛ6").GetChildNode("ОбобщПоказ");

            var document = new SixNdflDocument(
                documentNode.GetAttributeValue("КНД"),
                documentNode.GetAttributeValue("Период"),
                commonViewNode.GetAttributeValue<decimal>("НеУдержНалИт"),
                commonViewNode.GetAttributeValue<int>("КолФЛДоход")
            );


            var ratesNodes = commonViewNode.Elements("СумСтавка");
            foreach (var rate 
                in ratesNodes.Select(ratesNode => new SumRate(
                    ratesNode.GetAttributeValue("Ставка"),
                    ratesNode.GetAttributeValue<decimal>("НачислДох"),
                    ratesNode.GetAttributeValue<decimal>("НачислДохДив"),
                    ratesNode.GetAttributeValue<decimal>("ИсчислНал"))))
            {
                document.AddRate(rate);
            }

            var result = new SixNdfl(inn, kpp, reportYear, document);
            return result;
        }
    }
}