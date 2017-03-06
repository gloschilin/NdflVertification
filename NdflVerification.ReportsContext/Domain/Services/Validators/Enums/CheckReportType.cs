namespace NdflVerification.ReportsContext.Domain.Services.Validators.Enums
{
    /// <summary>
    /// Тип проверки
    /// </summary>
    public enum CheckReportType
    {
        /// <summary>
        /// Являться формой 6-НДФЛ, а не другой формой отчета. Проверка по форме.
        /// </summary>
        SixNdflForm,

        /// <summary>
        /// Быть годовой, а не квартальной. Проверка по периоду.
        /// </summary>
        SixNdflPeriod,

        /// <summary>
        /// Предусматривать расчет налога по ставке 13%. Проверка на ставку.
        /// </summary>
        SixNdflRate,

        /// <summary>
        /// Являться формой 2-НДФЛ, а не другой формой отчета. Проверка по форме.
        /// </summary>
        TwoNdflFrom,

        /// <summary>
        /// Иметь признак 1. Проверка по признаку.
        /// </summary>
        TwoNdflSign,

        /// <summary>
        /// Предусматривать расчет налога по ставке 13%. Проверка по ставке.
        /// </summary>
        TwoNdflRate,

        /// <summary>
        ///  Проверка по дате
        /// </summary>
        TwoNdflYear,

        /// <summary>
        /// Проверка по ИНН и КПП. 
        /// </summary>
        ReportsInnAndKpp,

        /// <summary>
        /// Проверка по дате.
        /// </summary>
        ReportsYear,

        /// <summary>
        /// Общая сумма дохода за год.
        /// </summary>
        ReportsTotalSum,

        /// <summary>
        /// Общая сумма дивидендов за год.
        /// </summary>
        ReportsTotalSumDividends,

        /// <summary>
        /// Общая сумма начисленных налогов за год.
        /// </summary>
        ReportsTotalSumTaxes,

        /// <summary>
        /// Общая сумма не удержанных налогов за год.
        /// </summary>
        ReportsTotalSumNotHoldTaxes,

        /// <summary>
        /// Количество ребят, получивших доход.
        /// </summary>
        ReportsTotalEmployeeCount
    }
}