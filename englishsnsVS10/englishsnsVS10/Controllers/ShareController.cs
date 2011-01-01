using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using englishsnsVS10.datacontext;
using englishsnsVS10.DAOimpl;

namespace englishsnsVS10.Controllers
{
    public class ShareController : Controller
    {
        //
        // GET: /Share/

        CustomerInfoRepo cr;


        public ActionResult Index(int id)
        {
            return View();
        }

        [HttpPost]
        public void Index(int id, FormCollection form)
        {
            share sh = new share();
            sh.explanationId = id;
            sh.sharecontent = form["comment"];
            sh.sharetime = DateTime.Now;
            var temp = cr.GetCustomer(User.Identity.Name);
            temp.First().shares.Add(sh);
            cr.save();
            Response.Write("Success");
        }
    }
}
