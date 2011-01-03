using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using englishsnsVS10.DAOimpl;
using englishsnsVS10.datacontext;

namespace englishsnsVS10.Controllers
{
    public class EditWordController : Controller
    {
        //
        // GET: /EditWord/

        EnglishDictRepo englishRepo;

        public ActionResult Index(int id)
        {
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

    }
}
