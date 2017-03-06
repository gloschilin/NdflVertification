using System.Collections.Generic;

namespace NdflVerification.Texts
{
    internal interface ITextRepository
    {
        IEnumerable<TextInfo> GetTexts();
    }
}