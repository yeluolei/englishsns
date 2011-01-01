using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using englishsnsVS10.Translate;
using englishsnsVS10.Models;

namespace englishsnsVS10.Controllers
{
    public class TranslationController : Controller
    {
        ITranslateBoundary googletranslate = new GoogleTranslateAdapter();
        ITranslateBoundary bingtranslate = new BingTranslateAdapter();
        //
        // GET: /Translation/
        public ActionResult Index()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult getTranslate(String Sentence, String languagechoose)
        {
            String source = Sentence;
            Sentence = Sentence.Trim();
            String googletranslateresult = googletranslate.requestTranslate(Sentence, languagechoose);
            String bingtranslateresult = bingtranslate.requestTranslate(Sentence, languagechoose);
            SentenceModels result = new SentenceModels(source, googletranslateresult, bingtranslateresult);
            return View(result);
        }

    }
}
