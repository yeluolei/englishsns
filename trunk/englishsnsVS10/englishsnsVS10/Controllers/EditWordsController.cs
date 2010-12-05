using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using englishsnsVS10.Models;

namespace englishsnsVS10.Controllers
{
    public class EditWordsController : Controller
    {
        private EnglishDictRepo dictRepo = new EnglishDictRepo();        
        //
        // GET: /EditWords/

        public ActionResult Index(string queryWord)
        {
            var sentence = dictRepo.getSentence(queryWord);
            var trans = dictRepo.getTranslate(queryWord);
            var ids = dictRepo.getTermID(queryWord);
            EditWordResult result = new EditWordResult(queryWord, sentence,trans,ids);
            return View(result);
        }

        //
        // GET: /EditWords/Edit

        public ActionResult Edit(int id)
        {
            return View(dictRepo.getTermbyId(id));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            terms editterm = dictRepo.getTermbyId(id);

            UpdateModel(editterm);
            if (editterm.sentence.Last() == '.')
                editterm.sentence = editterm.sentence.Substring(0,editterm.sentence.Length - 1);
            dictRepo.Save();
            return RedirectToAction("index", new { queryWord = editterm.word.theWord });
        }
    }
}
