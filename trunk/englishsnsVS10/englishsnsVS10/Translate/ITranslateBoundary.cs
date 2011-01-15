using System;
namespace englishsnsVS10.Translate
{
    public interface ITranslateBoundary
    {
        string requestTranslate(string SentenceEncode,string type);
    }
}
