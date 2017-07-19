namespace NdflVerification.Texts
{
    /// <summary>
    /// Информация о текстовом объекте
    /// </summary>
    public class TextInfo
    {
        public TextInfo(string name, string value, string otherValue)
        {
            OtherValue = otherValue;
            Name = name;
            Value = value;
        }

        public string OtherValue { get; }

        /// <summary>
        /// Наименование метки
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Значение метки
        /// </summary>
        public string Value { get;}
    }
}