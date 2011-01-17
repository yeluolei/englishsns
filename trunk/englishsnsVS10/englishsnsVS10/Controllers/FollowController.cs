using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using englishsnsVS10.DAOimpl;
using englishsnsVS10.datacontext;

namespace englishsnsVS10.Controllers
{
    public class FollowController : Controller
    {
        //
        // GET: /Follow/

        CustomerInfoRepo customerRepo;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Index(FormCollection form)
        {
            string follow = form["name"];
            string follower = User.Identity.Name;
            customerRepo.AddFollower(follow, follower);
            customerRepo.save();
        }

    }
}
