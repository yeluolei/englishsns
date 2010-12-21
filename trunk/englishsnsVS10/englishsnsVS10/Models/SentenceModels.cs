using System;
using System.Collections.Generic;

namespace englishsnsVS10.Models
{
    public class SentenceModels
    {
        public SentenceModels(String _TranslateSource , 
            String _GoogleTranslateResult,String _BingTranslateResult)
        {
            TranslateSource = _TranslateSource;
            GoogleTranslateResult = _GoogleTranslateResult;
            BingTranslateResult = _BingTranslateResult;
        }
        public String TranslateSource { get; private set; }
        public String GoogleTranslateResult { get; private set; }
        public String BingTranslateResult { get; private set; }
    }
}
