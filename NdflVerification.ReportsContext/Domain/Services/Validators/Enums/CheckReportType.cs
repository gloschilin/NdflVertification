
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
        Sv11Validator,
        Sv12Validator,
        Sv13Validator,
        Sv14Validator,
        Sv15Validator,
        Sv151Validator,
        Sv153Validator,
        Sv154Validator,
        Sv155Validator,
        Sv156Validator,
        Sv157Validator,
        Sv158Validator,
        Sv159Validator,
        Sv160Validator,
        Sv161Validator,
        Sv162Validator,
        Sv163Validator,
        Sv164Validator,
        Sv165Validator,
        Sv166Validator,
        Sv167Validator,
        Sv168Validator,
        Sv169Validator,
        Sv170Validator,
        Sv171Validator,
        Sv172Validator,
        Sv173Validator,
        Sv174Validator,
        Sv175Validator,
        Sv176Validator,
        Sv177Validator,
        Sv178Validator,
        Sv179Validator,
        Sv180Validator,
        Sv181Validator,
        Sv182Validator,
        Sv183Validator,
        Sv184Validator,
        Sv185Validator,
        Sv186Validator,
        Sv187Validator,
        Sv188Validator,
        Sv189Validator,
        Sv190Validator,
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
        Sv1123Validator,
        Sv1194Validator,
        Sv1195Validator,
        Sv1196Validator,
        Sv1197Validator,
        Sv1198Validator,
        Sv1199Validator,
        Sv1200Validator,
        Sv1201Validator,
        Sv1202Validator,
        Sv1203Validator,
        Sv1204Validator,
        Sv1205Validator,
        Sv1206Validator,
        Sv1207Validator,
        Sv1208Validator,
        Sv1209Validator,
        Sv1210Validator,
        Sv1211Validator,
        Sv1212Validator,
        Sv1213Validator,
        Sv1214Validator,
        Sv1215Validator,
        Sv1216Validator,
        Sv1217Validator,
        Sv1218Validator,
        Sv1219Validator,
        Sv1220Validator,
        Sv1221Validator,
        Sv1222Validator,
        Sv1223Validator,
        Sv1224Validator,
        Sv1225Validator,
        Sv1226Validator,
        Sv1227Validator,
        Sv1228Validator,
        Sv1229Validator,
        Sv1230Validator,
        Sv1231Validator,
        Sv1232Validator,
        Sv1233Validator,
        Sv1234Validator,
        Sv1235Validator,
        Sv1236Validator,
        Sv1237Validator,
        Sv1238Validator,
        Sv1239Validator,
        Sv1240Validator,
        Sv1241Validator,
        Sv1242Validator,
        Sv1243Validator,
        Sv1244Validator,
        Sv1245Validator,
        Sv1246Validator,
        Sv1255Validator,
        Sv1256Validator,
        Sv1257Validator,
        Sv1292Validator,
        Sv1303Validator,
        Sv16Validator,
        Sv150Validator,
        Sv149Validator,
        Sv148Validator,
        Sv147Validator,
        Sv146Validator,
        Sv145Validator,
        Sv144Validator,
        Sv143Validator,
        Sv142Validator,
        Sv141Validator,
        Sv140Validator,
        Sv139Validator,
        Sv138Validator,
        Sv137Validator,
        Sv136Validator,
        Sv135Validator,
        Sv134Validator,
        Sv133Validator,
        Sv132Validator,
        Sv131Validator,
        Sv130Validator,
        Sv129Validator,
        Sv128Validator,
        Sv127Validator,
        Sv126Validator,
        Sv125Validator,
        Sv124Validator,
        Sv123Validator,
        Sv122Validator,
        Sv121Validator,
        Sv113Validator,
        Sv112Validator,
        Sv111Validator,
        Sv110Validator,
        Sv109Validator,
        Sv108Validator,
        Sv107Validator,
        Sv106Validator,
        Sv19Validator,
        Sv18Validator,
        Sv17Validator,
        Sv1124Validator,
        Sv011Validator,
        Sv012Validator,
        Sv013Validator,
        Sv014Validator,
        Sv1293Validator,
        Sv1294Validator,
        Sv1295Validator,
        Sv1296Validator,
        Sv1297Validator,
        Sv1298Validator,
        Sv1299Validator,
        Sv1300Validator,
        Sv1301Validator,
        Sv1302Validator,
        Sv1304Validator,
        Sv1305Validator,
        Sv1306Validator,
        Sv1307Validator,
        Sv1308Validator,
        Total21Validator,
        Total22Validator,
        Total23Validator,
        Total24Validator,
        Total25Validator,
        Total26Validator,
        Sv015Validator
    }
}