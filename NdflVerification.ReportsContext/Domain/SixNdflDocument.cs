using System.Collections.Generic;

namespace NdflVerification.ReportsContext.Domain
{
    /// <summary>
    /// 6 НДФЛ. Файл => Документ 
    /// </summary>
    public class SixNdflDocument
    {
        public SixNdflDocument(string knd, string period, decimal notHoldTaxSum, int employeeCount)
        {
            Knd = knd;
            Period = period;
            NotHoldTaxSum = notHoldTaxSum;
            EmployeeCount = employeeCount;
            SumRates = new List<SumRate>();
        }


        /// <summary>
        /// Файл => Документ => @КНД
        /// </summary>
        public string Knd { get; }

        /// <summary>
        /// Файл => Документ => @Период
        /// </summary>
        public string Period { get; }

        /// <summary>
        /// Файл => Документ => НДФЛ6 => ОбобщПоказ => @НеУдержНалИт
        /// </summary>
        public decimal NotHoldTaxSum { get; }

        /// <summary>
        /// Файл => Документ => НДФЛ6 => ОбобщПоказ => @КолФЛДоход
        /// </summary>
        public int EmployeeCount { get; }

        /// <summary>
        /// Файл => Документ => НДФЛ6 => ОбобщПоказ => СумСтавка
        /// </summary>
        public List<SumRate> SumRates { get; }

        public void AddRate(SumRate rate)
        {
            SumRates.Add(rate);
        }
    }
}