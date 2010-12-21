using System;
namespace englishsnsVS10.Translate
{
    interface ITranslateBoundary
    {
        string requestTranslate(string SentenceEncode,string type);
    }
}
