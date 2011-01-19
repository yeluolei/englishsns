using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using englishsnsVS10.DAOimpl;
using englishsnsVS10.datacontext;
using englishsnsVS10.Models;
using englishsnsVS10.SystemInterfaces;

namespace englishsnsVS10.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /Comment/

        ICustomerInfoRepo customerRepo;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int id, FormCollection form)
        {
            comment c = new comment();
            c.shareid = id;
            c.comment1 = form["content"];
            c.time = DateTime.Now;
            user u = customerRepo.GetCustomer(User.Identity.Name);
            customerRepo.AddComment(c, u);
            //u.comments.Add(c);
            customerRepo.save();
            return View("Success");
        }

        public ActionResult GetComments(int id)
        {
            var comments = customerRepo.getcoments(id).ToList();
            //CommentModels result = new CommentModels(comments);
            return View(comments);
        }
    }
}
