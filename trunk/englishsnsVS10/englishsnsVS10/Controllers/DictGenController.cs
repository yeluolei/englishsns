using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Text.RegularExpressions;
using englishsnsVS10.Models;
using englishsnsVS10.DAO;
using System.IO;
using englishsnsVS10.datacontext;
namespace englishsnsVS10.Controllers
{
    public class DictGenController : Controller
    {
        englishdictDataContext db = new englishdictDataContext();
        //
        // GET: /DictGen/GenFromFile
        public ActionResult GenFromFile()
        { 
            var allexp = from exp in db.explanations
                         select exp;
            db.explanations.DeleteAllOnSubmit(allexp);
            var allword = from wd in db.words
                          select wd;
            db.words.DeleteAllOnSubmit(allword);
            db.SubmitChanges();//all table are empty now

            using (StreamReader sr = new StreamReader(Server.MapPath("cleandict.txt"))) {
                for (int i = 0; i < 100000; i++)
                {
                    String key = sr.ReadLine();
                    String expline = sr.ReadLine();
                    word newWord = new word();
                    newWord.wordname = key;
                    db.words.InsertOnSubmit(newWord);
                    foreach (String exp in new Regex(@"\s+\d+\s+").Split(expline))
                    {
                        if (key == null) break;
                        explanation newexp = new explanation();
                        newexp.expcontent = exp;
                        newexp.createdata = DateTime.Now;
                        newWord.explanations.Add(newexp);
                        db.explanations.InsertOnSubmit(newexp);
                    }
                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (System.Exception )
                    {
                    	db = new englishdictDataContext();
                    }
                    
                }
            }
            
            return View();
            
        }
        //
        // GET: /DictGen/SplitIt
        public ActionResult SplitIt() {
            var allexp = from exp in db.explanations
                         select exp;
            foreach(var oldExp in allexp) {
                Regex split = new Regex(@"\b+\d+\b+");
                String[] newExps = split.Split(oldExp.expcontent);
                
                foreach(string s in newExps) {
                    explanation newExp = new explanation();
                    
                    newExp.expcontent = s;
                    newExp.word = oldExp.word;
                    db.explanations.InsertOnSubmit(newExp);
                }
                db.explanations.DeleteOnSubmit(oldExp);
                db.SubmitChanges();
            }
            return View();
        }
    }
}
