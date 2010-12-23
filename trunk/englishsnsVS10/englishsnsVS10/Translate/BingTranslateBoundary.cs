using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bing;

namespace englishsnsVS10.Translate
{
    public class BingTranslateBoundary 
    {
        public string GetTranslateResult(string RequestSentence, string LanguageType)
        {
            String url = String.Empty;
            String source, target;
            if (LanguageType.Equals("EN_ZH"))
            {
                source = "En";
                target = "zh-CHS";
            }
            else
            {
                source = "zh-CHS";
                target = "En";
            }
            String result;
            SearchRequest searchRequest = new SearchRequest() {
                AppId = "B692A148D1624C4E3C1248C8E5DDC209E524D2C4", Query = RequestSentence, Market = "en-US" 
            }; 
	  
	        TranslationRequest translationRequest = new TranslationRequest();  
            translationRequest.SourceLanguage = source;
            translationRequest.TargetLanguage = target;
	  
            TranslationResponse response = API.Translation(searchRequest, translationRequest); 
	  
            if (response.TranslationResults.Count > 0)
            { 
                result = response.TranslationResults[0].TranslatedTerm;
            }
            else
            {
                result = "Can't get the translate from the bing translate";
            }
            return result;
        }
    }
}