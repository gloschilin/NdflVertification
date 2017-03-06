namespace NdflVerification.Texts
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITextDictionary
    {
        string this[string labelName]
        {
            get;
        }
    }
}