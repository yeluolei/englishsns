using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Index()
        {
            ViewData["Message"] = Message;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
