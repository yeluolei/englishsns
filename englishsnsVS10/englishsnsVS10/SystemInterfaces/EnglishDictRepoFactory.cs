using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using englishsnsVS10.DAOimpl;

namespace englishsnsVS10.SystemInterfaces
{
    public class EnglishDictRepoFactory
    {
        static IEnglishDictRepo edr = null;
        public static IEnglishDictRepo getEnglishDictRepo()
        {
            if (edr == null)
                edr = new EnglishDictRepo();
            return edr;
        }
    }
}