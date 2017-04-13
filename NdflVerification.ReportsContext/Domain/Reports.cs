
namespace NdflVerification.ReportsContext.Domain
{
    /// <summary>
    /// Отчеты 6 НДФЛ и ЕССС
    /// </summary>
    public class Reports
    {
        public Services.Factories.XsdImplement.Esss.Файл Esss { get; set; }
        public Services.Factories.XsdImplement.Six.Файл Ndfl6 { get; set; }
    }
}
