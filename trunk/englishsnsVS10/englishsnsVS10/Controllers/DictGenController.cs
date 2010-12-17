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
namespace englishsnsVS10.Controllers
{
    public class DictGenController : Controller
    {
        //
        // GET: /DictGen/
        englishdictDataContext db = new englishdictDataContext();
        public ActionResult Index()
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
                    String exp = sr.ReadLine();
                    if (key==null) break;
                    word newWord = new word();
                    newWord.wordname = key;
                    explanation newexp = new explanation();
                    newexp.expcontent = exp;
                    newWord.explanations.Add(newexp);
                    db.words.InsertOnSubmit(newWord);
                    db.explanations.InsertOnSubmit(newexp);
                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (System.Exception ex)
                    {
                    	db = new englishdictDataContext();
                        
                    }
                    
                }
            }
            
            return View();
            
        }

    }
}
