using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using englishsnsVS10.DAOimpl;
using englishsnsVS10.datacontext;
using englishsnsVS10.Models;
using englishsnsVS10.SystemInterfaces;

namespace englishsnsVS10.Controllers
{
    public class EditWordController : Controller
    {
        //
        // GET: /EditWord/

        
        IEnglishDictRepo englishRepo;

        public ActionResult Index(int id)
        {
            explanation exp = englishRepo.GetExplanation(id);
            string expcontent = exp.expcontent;
            string word = exp.wordname;
            ViewData["expcontent"] = expcontent;
            ViewData["word"] = word;
            return View();
        }

        [HttpPost]
        public ActionResult Index(int id, FormCollection form)
        {
            string translation = form["content"];
            explanation ex = new explanation();

            explanation temp = englishRepo.GetExplanation(id);

            if (temp.active == 1)
                temp.active = 0;
            if (temp.reference == -1)
                ex.reference = temp.id;
            else
                ex.reference = temp.reference;

            ex.expcontent = translation;
            ex.createdata = DateTime.Now;
            ex.wordname = temp.wordname;
            ex.active = 1;
            ex.modifier = User.Identity.Name;

            englishRepo.AddExplanation(ex);
            englishRepo.Save();

            return Redirect("/lookup/index?queryword="+temp.wordname);
        }

        public ActionResult Add(string word)
        {
            ViewData["word"] = word;
            return View();
        }

        [HttpPost]
        public ActionResult Add(string word,FormCollection form)
        {
            explanation exp = new explanation();
            exp.wordname = form["word"];
            exp.createdata = DateTime.Now;
            exp.modifier = User.Identity.Name;
            exp.reference = -1;
            exp.expcontent = form["content"];
            exp.active = 1;
            englishRepo.AddExplanation(exp);

            englishRepo.Save();
            return Redirect("/lookup/index?queryword=" + word);
        }

        public ActionResult Delete(int id)
        {
            var exp = englishRepo.GetExplanation(id);
            return View(exp);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            var exp = englishRepo.GetExplanation(id);
            var history = englishRepo.GetHistory(exp);
            if (exp.active == 1)
            {
                if (history.Count() > 1)
                {
                    var tempexp = history.Skip(history.Count()-2).FirstOrDefault();
                    //for (int i = history.Count() - 1; i >= 0; --i)
                    //{
                    //    if (history.ElementAt(i).active == 0)
                    //    {
                    //        history.ElementAt(i).active = 1;
                    //    }
                        tempexp.active = 1;
                    //}
                }
            }

            if (exp.modifier != "System")
            {
                exp.active = -1;
                //var exps = englishRepo.GetHistory(exp);
                englishRepo.Save();
            }
            return Redirect("/lookup/index?queryword=" + exp.wordname); ;
        }

        public ActionResult History(int id)
        {
            var exp = englishRepo.GetExplanation(id);
            var history = englishRepo.GetHistory(exp);
            var result = new LookUpWordResult(exp.wordname, history);
            return View(result);
        }

    }
}
