using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System.Json;
using System.ServiceModel.Web;

namespace englishsnsVS10.Translate
{
    public class GoogleTranslateBoundary
    {
        public String HandleTranslate(String SentenceIn, String TranslateType)
        {
            SentenceIn = SentenceIn.Replace(" ", "%20");
            String url = String.Empty;
            if (TranslateType.Equals("EN_ZH"))
            {
                url = String.Concat("https://www.googleapis.com/language/translate/v2?",
               "key=AIzaSyDdJRYhl1gCLRlJLymM20V1IwCBP9Vi58E&format=html&source=en&target=zh-CN&q=", SentenceIn);
            }
            else 
            {
                url = String.Concat("https://www.googleapis.com/language/translate/v2?",
               "key=AIzaSyDdJRYhl1gCLRlJLymM20V1IwCBP9Vi58E&format=html&source=zh-CN&target=en&q=", SentenceIn);
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
                result = "Error,can't get the translate result from Google Translate";
            }

            return result;
        }

        private String ProcessResult(String resultBefo)
        {
            //DataContractJsonSerializer Serialization = new DataContractJsonSerializer(typeof(GoogleTranslateData));
            //MemoryStream mstream = new MemoryStream(Encoding.Default.GetBytes(resultBefo));

            //GoogleTranslateData result = (GoogleTranslateData)Serialization.ReadObject(mstream);

            //return result.data.translations[0].translatedText;

            //try
            //{
            //    JsonObject result = JsonObject.Parse(resultBefo) as JsonObject;


            //    string returnresult;
            //    returnresult = result["data"]["translations"][0]["translatedText"];
            //    return returnresult;
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
            String result;
            String Temp;
            Temp = resultBefo.Substring(0, resultBefo.LastIndexOf('\"'));
            result = Temp.Substring(Temp.LastIndexOf('\"') + 1);
            return result;
        }
    }


}

//[DataContract(Namespace = "localhost:7001")]
//class GoogleTranslateData
//{
//    [DataMember(Order = 0)]
//    public GoogleTranslations data { get; set; }
//}

//[DataContract(Namespace = "localhost:7001")]
//class GoogleTranslations
//{
//    [DataMember(Order = 0)]
//    public TranslateResult[] translations { get; set; }
//}

//[DataContract(Namespace = "localhost:7001")]
//class TranslateResult
//{
//    [DataMember(Order = 0)]
//    public String translatedText { get; set; }
//    //[DataMember(Order=1)]
//    //public String detectedSourceLanguage{get;set;}
//}