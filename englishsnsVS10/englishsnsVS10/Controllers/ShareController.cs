using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using englishsnsVS10.datacontext;
using englishsnsVS10.DAOimpl;
using englishsnsVS10.SystemInterfaces;

namespace englishsnsVS10.Controllers
{
    public class ShareController : Controller
    {
        //
        // GET: /Share/

        ICustomerInfoRepo cr;


        public ActionResult Index(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int id, FormCollection form)
        {
            share sh = new share();
            sh.explanationId = id;
            sh.sharecontent = form["comment"];
            sh.sharetime = DateTime.Now;
            var u = cr.GetCustomer(User.Identity.Name);
            //u.shares.Add(sh);
            cr.AddShare(u, sh);
            cr.save();
            return View("success");
        }
    }
}
