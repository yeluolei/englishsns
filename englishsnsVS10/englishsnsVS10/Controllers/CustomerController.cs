using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using englishsnsVS10.DAOimpl;
using englishsnsVS10.datacontext;
using englishsnsVS10.Models;

using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;
using System.Web.Routing;
using System.Web.Security;
using System.Security.Cryptography;

namespace englishsnsVS10.Controllers
{
    public class CustomerController : Controller
    {
        CustomerInfoRepo customerInfoRepo = new CustomerInfoRepo();

        //
        // GET: /Customer/

        public ActionResult Index()
        {
            var user = customerInfoRepo.FindAllCustomer().ToList();
            return View("Index",user);
        }

        //
        // GET: /Customer/Details/5

        public ActionResult Details(string username)
        {
            user User = customerInfoRepo.GetCustomer(username);

            if (User == null)
            {
                return View("NotFound");
            }
            else
            {
                return View("Details", User);
            }
        }//not for now

        //
        // GET: /Customer/Create

        public ActionResult Create(string username)
        {
            //user User = new user();
            //return View("Create",User);
            user User = customerInfoRepo.GetCustomer(username);
            if (User == null || Roles.IsUserInRole(User.username, "admin") == true)
            {
                return View("NoteFound");
            }
            else
            {
                return View("Create", User);
            }
        } 

        //
        // POST: /Customer/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(string username, FormCollection collection)
        {
            //user User = new user();
            //try
            //{
            //    UpdateModel(User);
                //User
            //    Roles.AddUserToRole(User.username,"admin");
            //    customerInfoRepo.AddCustomer(User);
            //    customerInfoRepo.save();

                // TODO: Add insert logic here

           //     return RedirectToAction("Details", new { id = User.id });
            //}
            //catch
            //{
                
            //    return View("Create",User);
            //}
            user User = customerInfoRepo.GetCustomer(username);
            if (User == null || Roles.IsUserInRole(User.username, "admin") == true)
            {
                return View("NoteFount");
            }

            Roles.AddUserToRole(User.username, "admin");
            customerInfoRepo.save();
            return View("Created");
        }

        
        //
        // GET: /Customer/Edit/5
 
        public ActionResult Edit(string username)
        {
            user User = customerInfoRepo.GetCustomer(username);
            UserModels usermodel = new UserModels(User.id,User.username,User.name);
            return View("Edit",usermodel);
        }

        //
        // POST: /Customer/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(string username, FormCollection collection)
        {
            user User = customerInfoRepo.GetCustomer(username);
            try
            {
                // TODO: Add update logic here

                UpdateModel(User);
                customerInfoRepo.save();
                //User.id = Request.Form["CustomerID"];
                return RedirectToAction("Details", new { id = User.id });
            }
            catch
            {
                //ModelState.AddModelError(User.GetHashCode);
                return View("Edit",User);
            }
        }

        //
        // GET: /Customer/Delete/5
 
        public ActionResult Delete(string username)
        {
            user User = customerInfoRepo.GetCustomer(username);
            if (User == null || Roles.IsUserInRole(User.username, "admin") == false)
            {
                return View("NoteFound");
            }
            else
            {
                return View("Delete", User);
            }
            //return View();
        }

        //
        // POST: /Customer/Delete/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(string username, FormCollection collection)
        {
            user User = customerInfoRepo.GetCustomer(username);
            if (User == null || Roles.IsUserInRole(User.username, "admin") == false)
            {
                return View("NoteFound");
            }

            Roles.RemoveUserFromRole(User.username, "admin");
            customerInfoRepo.save();
            //return RedirectToAction("Deleted");
            return View("Deleted");
        }
    }
}
