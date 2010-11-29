using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using englishsnsVS10.Models;
namespace englishsnsVS10.Controllers
{
    public class LookUpController : Controller
    {
        //
        // GET: /LookUp/
        private EnglishDictRepo dictRepo = new EnglishDictRepo();
        public ActionResult Index()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(string queryWord) {
            var exps = dictRepo.getExplanations(queryWord);
            LookUpWordResult result = new LookUpWordResult(queryWord, exps);
            return View(result);
        }
    }
}
