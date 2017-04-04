
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
        Sv01Validator,
        Sv02Validator,
        Sv10Validator,
        Sv11Validator,
        Sv12Validator,
        Sv13Validator,
        Sv14Validator,
        Sv15Validator,
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
        Sv178Validator,
        Sv179Validator,
        Sv18Validator,
        Sv181Validator,
        Sv182Validator,
        Sv183Validator,
        Sv184Validator,
        Sv185Validator,
        Sv186Validator,
        Sv187Validator,
        Sv188Validator,
        Sv189Validator,
        Sv19Validator,
        Sv191Validator,
        Sv192Validator,
        Sv193Validator,
        Sv194Validator,
        Sv195Validator,
        Sv196Validator,
        Sv197Validator,
        Sv198Validator,
        Sv199Validator,
        Sv1100Validator,
        Sv1101Validator,
        Sv1102Validator,
        Sv1103Validator,
        Sv1104Validator,
        Sv1105Validator,
        Sv1106Validator,
        Sv1107Validator,
        Sv1108Validator,
        Sv1109Validator,
        Sv1110Validator,
        Sv1111Validator,
        Sv1112Validator,
        Sv1113Validator,
        Sv1114Validator,
        Sv1115Validator,
        Sv1116Validator,
        Sv1117Validator,
        Sv1118Validator,
        Sv1119Validator,
        Sv1120Validator,
        Sv1121Validator,
        Sv1122Validator,
        Sv1123Validator
    }
}