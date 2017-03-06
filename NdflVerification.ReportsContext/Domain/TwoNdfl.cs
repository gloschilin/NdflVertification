using System.Collections.Generic;
using System.Linq;

namespace NdflVerification.ReportsContext.Domain
{
    /// <summary>
    /// Два НДФЛ
    /// </summary>
    public class TwoNdfl
    {
        public TwoNdfl(string reportYear)
        {
            ReportYear = reportYear;
            Documents = new List<TwoNdflDocument>();
        }

        /// <summary>
        /// Файл => Документ
        /// </summary>
        public List<TwoNdflDocument> Documents { get; }

        /// <summary>
        /// Файл => СвРекв => ОтчетГод
        /// </summary>
        public string ReportYear { get; }

        /// <summary>
        /// Получить общую сумму дохода за год
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalSum()
        {
            return Documents.Sum(e => e.ToalSummYear);
        }

        /// <summary>
        /// Общая сумма дивидендов за год.
        /// </summary>
        public decimal GetTotalDividendsSum()
        {
            return Documents.SelectMany(e => e.Dividends).Where(e => e.Code == "1010").Sum(e => e.Sum);
        }

        /// <summary>
        /// Общая сумма начисленных налогов за год.
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalTaxesSum()
        {
            return Documents.Sum(e => e.ToalSummYear);
        }

        /// <summary>
        /// Общая сумма не удержанных налогов за год.
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalNotHoldTaxesSum()
        {
            return Documents.Sum(e => e.NotHoldTaxSum);
        }

        /// <summary>
        /// Количество ребят, получивших доход.
        /// </summary>
        /// <returns></returns>
        public int GetTotalEmployeeCount()
        {
            return Documents.Count;
        }
    }
}
