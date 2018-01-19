using System;
using System.Linq;
using System.Text;
using Ndfl = NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Six.Файл;
using Esss = NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss.Файл;
using FlNdFl = NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Six.ФайлДокументСвНПНПФЛ;
using FlNdUl = NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Six.ФайлДокументСвНПНПЮЛ;

using EsssFl = NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss.ФайлДокументСвНПНПФЛ;
using EsssUl = NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss.ФайлДокументСвНПНПЮЛ;

namespace NdflVertification.Web.Api.Utils
{
    public interface IReportInfoBuilder<in TReport>
    {
        void Build(StringBuilder builder, TReport report, int actionId, DateTime fileDate);
    }

    public class EsssInfoBuilder : IReportInfoBuilder<Esss>
    {
        public void Build(StringBuilder builder, Esss report, int actionId, DateTime fileDate)
        {
            var inn = (report.Документ.СвНП.Item as EsssFl)?.Item
                      ?? (report.Документ.СвНП.Item as EsssUl)?.ИННЮЛ;

            builder.AppendLine($"ESSS|{actionId}|{inn}|{report.Документ.ОтчетГод}|" +
                               $"{report.Документ.Период}|{fileDate}|" +
                               $"{report.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.First().РасчСВ_ОПС.КолСтрахЛицВс.КолВсегоПер}");
        }
    }

    public class NdflInfoBuilder: IReportInfoBuilder<Ndfl>
    {
        public void Build(StringBuilder builder, Ndfl report, int actionId, DateTime fileDate)
        {
            var inn = (report.Документ.СвНП.Item as FlNdFl)?.ИННФЛ
                      ?? (report.Документ.СвНП.Item as FlNdUl)?.ИННЮЛ;

            builder.AppendLine($"6NDFL|{actionId}|{inn}|{report.Документ.ОтчетГод}|{report.Документ.Период}|{fileDate}|");
        }
    }
}