using System.Collections.Generic;

namespace NdflVerification.ReportsContext.Domain
{
    /// <summary>
    /// Общая сумма дивидендов. Два НДФЛ. Файл => Документ => СведДох => ДохВыч => СвСумДох
    /// </summary>
    public class Dividend
    {
        public Dividend(string code, decimal sum)
        {
            Code = code;
            Sum = sum;
        }

        /// <summary>
        /// Два НДФЛ. Файл => Документ => СведДох => ДохВыч => СвСумДох => @КодДоход
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Два НДФЛ. Файл => Документ => СведДох => ДохВыч => СвСумДох => @СумДоход
        /// </summary>
        public decimal Sum { get; }
    }

    /// <summary>
    /// Два НДФЛ. Файл => Документ
    /// </summary>
    public class TwoNdflDocument
    {
        public TwoNdflDocument(string knd, string inn, string kpp, 
            string reportYear, string sign, string rate, Person person, decimal taxSum, decimal toalSummYear, decimal notHoldTaxSum)
        {
            Knd = knd;
            Inn = inn;
            Kpp = kpp;
            ReportYear = reportYear;
            Sign = sign;
            Rate = rate;
            Person = person;
            TaxSum = taxSum;
            ToalSummYear = toalSummYear;
            NotHoldTaxSum = notHoldTaxSum;
            Dividends = new List<Dividend>();
        }

        /// <summary>
        /// Начисленная сумма налога. Два НДФЛ. Файл => Документ => СведДох => СумИтНалПер => @НалИсчисл
        /// </summary>
        public decimal TaxSum { get; }

        /// <summary>
        /// Общая сумма дохода за год. Два НДФЛ. Файл => Документ => СведДох => СумИтНалПер => @НалНеУдерж
        /// </summary>
        public decimal ToalSummYear { get; }

        /// <summary>
        /// Общая сумма дивидендов. Два НДФЛ. Файл => Документ => СведДох => ДохВыч => СвСумДох
        /// </summary>
        public List<Dividend> Dividends { get; }

        /// <summary>
        /// НалНеУдерж. Два НДФЛ. Файл => Документ => СведДох => СумИтНалПер => @НалНеУдерж
        /// </summary>
        public decimal NotHoldTaxSum { get; } 

        /// <summary>
        /// Два НДФЛ. Файл => Документ => ПолучДох
        /// </summary>
        public Person Person { get; }

        /// <summary>
        /// Файл => Документ => @КНД
        /// </summary>
        public string Knd { get; }

        /// <summary>
        /// Файл => Документ => СвНА => (СвНАЮЛ | ???) => (@ИННЮЛ | ???)
        /// </summary>
        public string Inn { get; }

        /// <summary>
        /// Файл => Документ => СвНА => (СвНАЮЛ | ???) => (@КПП | ???)
        /// </summary>
        public string Kpp { get; }

        /// <summary>
        /// Файл => Документ => @ОтчетГод
        /// </summary>
        public string ReportYear { get; }

        /// <summary>
        /// Файл => Документ => @Признак
        /// </summary>
        public string Sign { get; }

        /// <summary>
        /// Файл => Документ => СведДох => @Ставка
        /// </summary>
        public string Rate { get; }
    }
}