namespace NdflVerification.ReportsContext.Domain
{
    /// <summary>
    ///   6 НДФЛ. Файл => Документ => НДФЛ6 => ОбобщПоказ => СумСтавка
    /// </summary>
    public class SumRate
    {
        public SumRate(string rate, decimal totalSum, decimal dividentsSum, decimal taxSum)
        {
            Rate = rate;
            TotalSum = totalSum;
            DividentsSum = dividentsSum;
            TaxSum = taxSum;
        }

        /// <summary>
        /// Файл => Документ => НДФЛ6 => ОбобщПоказ => СумСтавка => @Ставка
        /// </summary>
        public string Rate { get; }

        /// <summary>
        /// Общая сумма дохода за год. Файл => Документ => НДФЛ6 => ОбобщПоказ => СумСтавка => @НачислДох
        /// </summary>
        public decimal TotalSum { get; }

        /// <summary>
        /// Общая сумма дивидендов. Файл => Документ => НДФЛ6 => ОбобщПоказ => СумСтавка => @НачислДохДив
        /// </summary>
        public decimal DividentsSum { get; }

        /// <summary>
        /// Начисленная сумма налога. Файл => Документ => НДФЛ6 => ОбобщПоказ => СумСтавка => @ИсчислНал
        /// </summary>
        public decimal TaxSum { get; }
    }
}