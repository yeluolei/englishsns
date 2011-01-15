using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using englishsnsVS10.DAOimpl;
using englishsnsVS10.datacontext;
using englishsnsVS10.Models;
using englishsnsVS10.DAO;

namespace englishsnsVS10.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        string Message
        {
            get;
            set;
        }

        CustomerInfoRepo customerRepo;
        EnglishDictRepo englishDictRepo;

        public ActionResult Index()
        {
            ViewData["Message"] = Message;
            List<ShareModels> sharesList = new List<ShareModels>();
            if (Request.IsAuthenticated)
            {
                
                string userAccount = User.Identity.Name;
                user customer = customerRepo.GetCustomer(userAccount);
                var followedPeoples = customerRepo.GetFollowedPeople(customer);
                foreach (var followedPeople in followedPeoples)
                {
                    var shares = customerRepo.getshares(followedPeople.userid);
                    List<explanation> explanations = new List<explanation>();
                    List<string> names = new List<string>();
                    foreach (var s in shares)
                    {
                        user temp = customerRepo.GetCustomer(s.userid);
                        names.Add(temp.name);
                        explanations.Add(englishDictRepo.GetExplanation(s.explanationId));
                    }

                    sharesList.Add(new ShareModels(shares,names,explanations));
                }
            }
            return View(sharesList);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
