using System;
using System.Xml.Linq;
using NdflVerification.ReportsContext.Utils;

namespace NdflVerification.ReportsContext.Domain.Services.Factories
{
    /// <summary>
    /// Сборщик отчета 2НДФЛ
    /// </summary>
    internal class NdflTwoXmlReportBuilder: IXmlReportBuilder<TwoNdfl>
    {
        public TwoNdfl BuildFromXml(XDocument xmlDocument)
        {
            var fileNode = xmlDocument.GetRootNode("Файл");
            //СвРекв
            var svRekv = fileNode.GetChildNode("СвРекв");
            var reportYear = svRekv.GetAttributeValue("ОтчетГод");
            
            var  result = new TwoNdfl(reportYear);

            var documentNodes = fileNode.Descendants("Документ");
            foreach (var documentNode in documentNodes)
            {
                var knd = documentNode.GetAttributeValue("КНД");
                string inn;
                string kpp;

                var svNa = documentNode.GetChildNode("СвНА");
                XElement sv;
                if (svNa.TryGetChildNode("СвНАЮЛ", out sv))
                {
                    inn = sv.GetAttributeValue("ИННЮЛ");
                    kpp = sv.GetAttributeValue("КПП");
                }
                else
                {
                    throw new NotImplementedException("Нет реализации для ИП");
                }

                var documentReportYear = documentNode.GetAttributeValue("ОтчетГод");
                var sign = documentNode.GetAttributeValue("Признак");
                var svDohNode = documentNode.GetChildNode("СведДох");
                var rate = svDohNode.GetAttributeValue("Ставка");
                //ПолучДох
                var polDoNode = documentNode.GetChildNode("ПолучДох");
                var fioNode = polDoNode.GetChildNode("ФИО");

                var sumInNalPer = svDohNode.GetChildNode("СумИтНалПер");
                var taxSum = sumInNalPer.GetAttributeValue<decimal>("СумДохОбщ");
                var totalSumYear = sumInNalPer.GetAttributeValue<decimal>("СумДохОбщ");
                var notHoldTaxSum = sumInNalPer.GetAttributeValue<decimal>("НалНеУдерж");

                var document = new TwoNdflDocument(knd, inn, kpp, documentReportYear, sign, rate,
                    new Person(
                        fioNode.GetAttributeValue("Фамилия"),
                        fioNode.GetAttributeValue("Имя"),
                        fioNode.GetAttributeValue("Отчество")
                        ), taxSum, totalSumYear, notHoldTaxSum);

                //document.Dividends
                foreach (var sumSvedDohNode in svDohNode.GetChildNode("ДохВыч").Elements("СвСумДох"))
                {
                    var divident = new Dividend(
                        sumSvedDohNode.GetAttributeValue("КодДоход"),
                        sumSvedDohNode.GetAttributeValue<decimal>("СумДоход")
                    );
                    document.Dividends.Add(divident);
                }

                result.Documents.Add(document);
            }
            return result;
        }
    }
}