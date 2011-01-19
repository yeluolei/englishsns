using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace englishsnsVS10.Translate
{
    public class BingTranslateAdapter : BingTranslateBoundary , ITranslateAdapter
    {
         public String requestTranslate(String SentenceEncode, String type)
         {
             return this.GetTranslateResult(SentenceEncode, type);
         }
    }
}