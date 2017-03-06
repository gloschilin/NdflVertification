namespace NdflVerification.ReportsContext.Domain
{
    /// <summary>
    /// Два НДФЛ. Файл => Документ => ПолучДох => ФИО
    /// </summary>
    public class Person
    {
        public Person(string f, string unknown, string o)
        {
            F = f;
            I = unknown;
            O = o;
        }

        /// <summary>
        /// Два НДФЛ. Файл => Документ => ПолучДох => ФИО => Фамилия
        /// </summary>
        public string F { get; }

        /// <summary>
        /// Два НДФЛ. Файл => Документ => ПолучДох => ФИО => Имя
        /// </summary>
        public string I { get; }

        /// <summary>
        /// Два НДФЛ. Файл => Документ => ПолучДох => ФИО => Отчество
        /// </summary>
        public string O { get; }
    }
}