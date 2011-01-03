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

    }
}
