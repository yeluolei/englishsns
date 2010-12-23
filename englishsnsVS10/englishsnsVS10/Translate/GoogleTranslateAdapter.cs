using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace englishsnsVS10.Translate
{
    public class GoogleTranslateAdapter : GoogleTranslateBoundary,ITranslateBoundary
    {
         public String requestTranslate(String SentenceEncode, String type)
         {
             return this.HandleTranslate(SentenceEncode, type);
         }
    }
}