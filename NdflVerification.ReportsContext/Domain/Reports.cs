namespace NdflVerification.ReportsContext.Domain
{
    /// <summary>
    /// Отчеты 2 и 6 НДФЛ
    /// </summary>
    public class Reports
    {
        public Reports(SixNdfl sixNdfl, TwoNdfl twoNdfl)
        {
            SixNdfl = sixNdfl;
            TwoNdfl = twoNdfl;
        }

        /// <summary>
        /// Отчет 6НДФЛ
        /// </summary>
        public SixNdfl SixNdfl { get; }

        /// <summary>
        /// Отчет 2НДФЛ
        /// </summary>
        public TwoNdfl TwoNdfl { get; }
    }
}
