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
        ReportsTotalEmployeeCount,

        /// <summary>
        /// СВ01
        /// </summary>
        EsssSv01Validator,
        Sv152Validator,
        Sv153Validator,
        Sv154Validator,
        Sv155Validator,
        Sv156Validator,
        Sv157Validator,
        Sv158Validator,
        Sv159Validator,
        Sv16Validator,
        Sv161Validator,
        Sv162Validator,
        Sv163Validator,
        Sv164Validator,
        Sv165Validator,
        Sv166Validator,
        Sv167Validator,
        Sv168Validator,
        Sv169Validator,
        Sv17Validator,
        Sv171Validator,
        Sv172Validator,
        Sv173Validator,
        Sv174Validator,
        Sv175Validator,
        Sv176Validator,
        Sv177Validator,
        Sv178Validator
    }
}