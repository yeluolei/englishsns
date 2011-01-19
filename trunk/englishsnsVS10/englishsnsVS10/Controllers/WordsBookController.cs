using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using englishsnsVS10.DAOimpl;
using englishsnsVS10.datacontext;
using englishsnsVS10.SystemInterfaces;

namespace englishsnsVS10.Controllers
{
    public class WordsBookController : Controller
    {
        //
        // GET: /WordsBook/

        ICustomerInfoRepo customerRepo;

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add( string wd )
        {
            wordsbook wb = new wordsbook();
            wb.wordname = wd;
            user u = customerRepo.GetCustomer(User.Identity.Name);
            wb.userid = u.id;
            customerRepo.AddWordsbook(wb);
            customerRepo.save();
            return View("success");
        }

        public ActionResult GetWordsBook()
        {
            user u = customerRepo.GetCustomer(User.Identity.Name);
            var wordsbookCollect = customerRepo.GetWordsBook(u.id).ToList();
            return View(wordsbookCollect);
        }

    }
}
