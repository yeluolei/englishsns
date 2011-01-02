using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using englishsnsVS10.DAOimpl;
using englishsnsVS10.datacontext;

namespace englishsnsVS10.Controllers
{
    public class WordsBookController : Controller
    {
        //
        // GET: /WordsBook/

        CustomerInfoRepo customerRepo;

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add( string wd )
        {
            wordsbook wb = new wordsbook();
            wb.wordname = wd;
            user u = customerRepo.GetCustomer(User.Identity.Name).First();
            wb.userid = u.id;
            customerRepo.AddWordsbook(wb);
            customerRepo.save();
            return Redirect("shared/success");
        }

        public ActionResult GetWordsBook()
        {
            user u = customerRepo.GetCustomer(User.Identity.Name).First();
            var wordsbookCollect = customerRepo.GetWordsBook(u.id).ToList();
            return View(wordsbookCollect);
        }

    }
}
