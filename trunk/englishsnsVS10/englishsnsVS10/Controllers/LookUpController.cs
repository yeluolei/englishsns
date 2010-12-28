using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using englishsnsVS10.Models;
using englishsnsVS10.DAO;
using System.Text.RegularExpressions;
using englishsnsVS10.DAOimpl;
namespace englishsnsVS10.Controllers
{
    public class LookUpController : Controller
    {
        //
        // GET: /LookUp/
        private EnglishDictRepo dictRepo = EnglishDictRepoFactory.getInstance();
        public ActionResult Index()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(string queryWord)
        {
            var exps = dictRepo.getExplanations(queryWord);
            String[] splittedexps = new String[1];

            if (exps.Count() == 0)
                splittedexps = null;
            else
                foreach (string s in exps)
                {
                    Regex rx = new Regex(@"\s+\d+\s+");
                    splittedexps = rx.Split(s);
                }
            LookUpWordResult result = new LookUpWordResult(queryWord, splittedexps==null?null:splittedexps.ToList());
            return View(result);
        }
    }
}
