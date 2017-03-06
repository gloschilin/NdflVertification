using System.Linq;

namespace NdflVerification.ReportsContext.Domain
{
    /// <summary>
    /// 6 НДФЛ
    /// </summary>
    public class SixNdfl
    {
        public SixNdfl(string inn, string kpp, string reportYear, SixNdflDocument document)
        {
            Inn = inn;
            Kpp = kpp;
            ReportYear = reportYear;
            Document = document;
        }
        
        /// <summary>
        /// Файл => Документ
        /// </summary>
        public SixNdflDocument Document { get; }

        /// <summary>
        /// Файл => Документ => СвНП => (НПЮЛ | ??) => (@ИННЮЛ | ???)
        /// </summary>
        public string Inn { get; }

        /// <summary>
        /// Файл => Документ => СвНП => (НПЮЛ | ??) => (@КПП | ???)
        /// </summary>
        public string Kpp { get; }

        /// <summary>
        /// Файл => Документ => @ОтчетГод
        /// </summary>
        public string ReportYear { get; }

        /// <summary>
        /// Получить общую сумму дохода за год
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalSum()
        {
            return Document.SumRates.Sum(e => e.TotalSum);
        }

        /// <summary>
        /// Общая сумма дивидендов за год.
        /// </summary>
        public decimal GetTotalDividendsSum()
        {
            return Document.SumRates.Sum(e => e.DividentsSum);
        }

        /// <summary>
        /// Общая сумма начисленных налогов за год.
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalTaxesSum()
        {
            return Document.SumRates.Sum(e => e.TaxSum);
        }

        /// <summary>
        /// Общая сумма не удержанных налогов за год.
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalNotHoldTaxesSum()
        {
            return Document.NotHoldTaxSum;
        }

        /// <summary>
        /// Количество ребят, получивших доход.
        /// </summary>
        /// <returns></returns>
        public int GetTotalEmployeeCount()
        {
            return Document.EmployeeCount;
        }
    }
}
