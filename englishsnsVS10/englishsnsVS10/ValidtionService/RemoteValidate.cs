using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using englishsnsVS10.SystemInterfaces;

namespace englishsnsVS10.ValidtionService
{
    public class RemoteValidate : ILoginValidation
    {
        public bool validate(string text, string ticket)
        {
            string url = "http://jaccount.sjtu.in/validation.php?key=" + text + "&ticket=" + ticket;
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            string result;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                result = reader.ReadToEnd();
            }

            if (result == "1")
            {
                return true;
            }
            else
                return false;
        }
    }
}