using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using englishsnsVS10.SystemInterfaces;
using englishsnsVS10.ValidtionService;

namespace englishsnsVS10.ValidtionService
{
    public class ValidationProxy: ILoginValidation
    {
        ILoginValidation remote;
        ILoginValidation local;

        public bool validate(string text, string ticket)
        {
            remote = new RemoteValidate();
            bool result;
            try
            {
                result = remote.validate(text, ticket);
            }
            catch
            {
                local = new LocalValidate();
                result = local.validate(text, ticket);
            }

            return result;
        }
    
    }
}