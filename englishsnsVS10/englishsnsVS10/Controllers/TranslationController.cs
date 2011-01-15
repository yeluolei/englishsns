using System;
using System.Web.Mvc;
using englishsnsVS10.Translate;
using englishsnsVS10.Models;

namespace englishsnsVS10.Controllers
{
    public class TranslationController : Controller
    {
        ITranslateBoundary googletranslate = TranslateFactory.getInstance().getGoogleTranslate();
        ITranslateBoundary bingtranslate = TranslateFactory.getInstance().getBingTranslate();
        //
        // GET: /Translation/
        public ActionResult Index()
        {
            return View();
        }
        //
        // POST: /Translation/
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TranslateResult(String Sentence, String languagechoose)
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
