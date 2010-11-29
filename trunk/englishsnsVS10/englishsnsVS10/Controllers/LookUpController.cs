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
            var result = dictRepo.getExplanation(queryWord);
            return View(result);
        }
    }
}
