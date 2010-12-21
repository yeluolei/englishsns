using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;

namespace englishsnsVS10.Translate
{
    public class GoogleTranslateBoundary : englishsnsVS10.Translate.ITranslateBoundary
    {
        public String requestTranslate(String SentenceEncode,String type){
            SentenceEncode = SentenceEncode.Replace(" ", "%20");
            String url = String.Empty;
            if (type.Equals("EN_ZH"))
            {
                url = String.Concat("https://www.googleapis.com/language/translate/v2?",
               "key=AIzaSyDdJRYhl1gCLRlJLymM20V1IwCBP9Vi58E&format=html&source=en&target=zh-CN&q=", SentenceEncode);
            }
            else 
            {
                url = String.Concat("https://www.googleapis.com/language/translate/v2?",
               "key=AIzaSyDdJRYhl1gCLRlJLymM20V1IwCBP9Vi58E&format=html&source=zh-CN&target=en&q=", SentenceEncode);
            }
            String result = String.Empty;
            HttpWebRequest request = null;
            try{
                request = WebRequest.Create(url) as HttpWebRequest;
                using(HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    result = reader.ReadToEnd();
                }
                result = ProcessResult(result);
            }catch(Exception){
                result = "Error,can't get the translate result";
            }

            return result;
        }

        private String ProcessResult(String resultBefo)
        {
            String result;
            String Temp;
            Temp = resultBefo.Substring(0, resultBefo.LastIndexOf('\"'));
            result = Temp.Substring(Temp.LastIndexOf('\"') + 1);
            return result;
        }
    }


}