using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace englishsnsVS10.Translate
{
    public class TranslateFactory
    {
        public ITranslateAdapter getGoogleTranslate(){
            return new GoogleTranslateAdapter();
        }
        public ITranslateAdapter getBingTranslate()
        {
            return new BingTranslateAdapter();
        }

        public static TranslateFactory getInstance()
        {
            if (translatefactory == null)
            {
                translatefactory = new TranslateFactory();
            }
            return translatefactory;
        }

        private static TranslateFactory translatefactory;
    }
}