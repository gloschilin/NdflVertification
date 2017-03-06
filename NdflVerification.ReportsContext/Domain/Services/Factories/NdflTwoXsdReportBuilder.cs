using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Two;

namespace NdflVerification.ReportsContext.Domain.Services.Factories
{
    /*
     * http://format.nalog.ru/
     * Получение необходимых XSD схем
     */

    /// <summary>
    /// Получение данные путем десериализации в объект из XSD схемы
    /// </summary>
    public class NdflTwoXsdReportBuilder: IXmlReportBuilder<TwoNdfl>
    {
        public TwoNdfl BuildFromXml(XDocument xmlDocument)
        {
            Файл xsdResult;

            var serializer = new XmlSerializer(typeof(Файл));

            using (var reader = new StringReader(xmlDocument.ToString()))
            {
                xsdResult = (Файл)serializer.Deserialize(reader);
            }

            var result = new TwoNdfl(xsdResult.СвРекв.ОтчетГод);
            foreach (var documentNode in xsdResult.Документ)
            {
                var fiz = documentNode.СвНА.Item as ФайлДокументСвНАСвНАФЛ;
                var ul = documentNode.СвНА.Item as ФайлДокументСвНАСвНАЮЛ;
                var inn = fiz?.ИННФЛ ?? ul?.ИННЮЛ;
                var kpp = ul?.КПП;

                var document = new TwoNdflDocument(documentNode.КНД, inn, kpp, documentNode.ОтчетГод,
                    documentNode.Признак, documentNode.СведДох.First().Ставка, new Person(
                        documentNode.ПолучДох.ФИО.Фамилия,
                        documentNode.ПолучДох.ФИО.Имя,
                        documentNode.ПолучДох.ФИО.Отчество
                        ),
                    documentNode.СведДох.First().СумИтНалПер.НалИсчисл,
                    documentNode.СведДох.First().СумИтНалПер.СумДохОбщ,
                    documentNode.СведДох.First().СумИтНалПер.НалНеУдерж);

                result.Documents.Add(document);

                foreach (var dohich in documentNode.СведДох.SelectMany(e=>e.ДохВыч))
                {
                    var divident = new Dividend(
                        dohich.КодДоход,
                        dohich.СумДоход
                    );
                    document.Dividends.Add(divident);
                }
            }

            return result;
        }
    }
}