using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using englishsnsVS10.DAOimpl;
using englishsnsVS10.datacontext;
using englishsnsVS10.Models;

namespace englishsnsVS10.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /Comment/

        CustomerInfoRepo customerRepo;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Index(int id, FormCollection form)
        {
            comment c = new comment();
            c.shareid = id;
            c.comment1 = form["content"];
            c.time = DateTime.Now;
            user u = customerRepo.GetCustomer(User.Identity.Name);
            u.comments.Add(c);
            customerRepo.save();

            Response.Write("sucess");
        }

        public ActionResult GetComments(int id)
        {
            var comments = customerRepo.getcoments(id).ToList();
            //CommentModels result = new CommentModels(comments);
            return View(comments);
        }
    }
}
