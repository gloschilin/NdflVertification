using System;
using System.Collections.Generic;
using System.Linq;

namespace NdflVerification.Texts
{

    public class Text
    {
        public string Value { get; set; }
        public bool Error { get; set; }
    }

    internal class TextDictionary: ITextDictionary
    {
        private readonly ITextRepository _textRepository;

        private IEnumerable<TextInfo> _texts;

        private IEnumerable<TextInfo> Texts
            => _texts ?? (_texts = _textRepository.GetTexts());

        public TextDictionary(ITextRepository textRepository)
        {
            _textRepository = textRepository;
        }

        public string GetText(string label, int quarter)
        {
            var textItem = Texts.FirstOrDefault(e => e.Name == label);
            if (textItem == null)
            {
                return null;
            }

            if (quarter == 1)
            {
                return textItem.Value.HandleText(quarter);
            }

            var text = (string.IsNullOrEmpty(textItem.OtherValue)
                ? textItem.Value
                : textItem.OtherValue).HandleText(quarter);

            return text;
        }
    }

    public static class ErrorMessageExtentions
    {
        private const string Code = "{quarter}";

        public static string HandleText(this string text, int quarter)
        {
            switch (quarter)
            {
                case 1:
                    return text.Replace(Code, "первый квартал");
                case 2:
                    return text.Replace(Code, "полугодие");
                case 3:
                    return text.Replace(Code, "9 месяцев");
                case 4:
                    return text.Replace(Code, "год");
                default: throw new ApplicationException();
            }
        }
    }
}
