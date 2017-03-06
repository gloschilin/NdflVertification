using System.Collections.Generic;
using System.Linq;

namespace NdflVerification.Texts
{
    internal class TextDictionary: ITextDictionary
    {
        private readonly ITextRepository _textRepository;

        private Dictionary<string, string> _texts;

        private Dictionary<string, string> Texts
            => _texts ?? (_texts = _textRepository.GetTexts().ToDictionary(e => e.Name, v => v.Value));

        public TextDictionary(ITextRepository textRepository)
        {
            _textRepository = textRepository;
        }

        public string this[string labelName] => !Texts.ContainsKey(labelName) ? null : Texts[labelName];
    }
}
