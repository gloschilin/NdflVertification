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

            return quarter == 1
                ? textItem.OtherValue
                : textItem.Value;
        }
    }
}
