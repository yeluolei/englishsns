using System;
namespace englishsnsVS10.Translate
{
    public interface ITranslateAdapter
    {
        string requestTranslate(string SentenceEncode,string type);
    }
}
