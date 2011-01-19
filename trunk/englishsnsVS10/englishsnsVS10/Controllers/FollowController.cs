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
    public class FollowController : Controller
    {
        //
        // GET: /Follow/

        ICustomerInfoRepo customerRepo;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string follow = form["name"];
            string follower = User.Identity.Name;
            customerRepo.AddFollower(follow, follower);
            customerRepo.save();
            return View();
        }

        public ActionResult AllFollower()
        {
            string name = User.Identity.Name;
            user u = customerRepo.GetCustomer(name);
            var follows = customerRepo.GetFollowedPeople(u);
            return View(follows);      
        }

    }
}
