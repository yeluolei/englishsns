using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using englishsnsVS10.DAOimpl;
using englishsnsVS10.datacontext;
using englishsnsVS10.Models;

namespace englishsnsVS10.DAOimpl
{
    public class CustomerController : Controller
    {
        CustomerInfoRepo customerInfoRepo = new CustomerInfoRepo();

        //
        // GET: /Customer/

        public ActionResult Index(string account)
        {
            var user = customerInfoRepo.GetCustomer(account).ToList();
            return View("Index",user);
        }

        //
        // GET: /Customer/Details/5

        public ActionResult Details(int id)
        {
            user User = customerInfoRepo.GetCustomer(id);

            if (User == null)
            {
                return View("NotFound");
            }
            else
            {
                return View("Details", User);
            }
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            user User = new user();
            return View("Create",User);
        } 

        //
        // POST: /Customer/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            user User = new user();
            try
            {
                UpdateModel(User);
                customerInfoRepo.AddCustomer(User);
                customerInfoRepo.save();

                // TODO: Add insert logic here

                return RedirectToAction("Details", new { id = User.id });
            }
            catch
            {
                
                return View("Create",User);
            }
        }
        
        //
        // GET: /Customer/Edit/5
 
        public ActionResult Edit(int id)
        {
            user User = customerInfoRepo.GetCustomer(id);
            return View("Edit",User);
        }

        //
        // POST: /Customer/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            user User = customerInfoRepo.GetCustomer(id);
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
 
        public ActionResult Delete(int id)
        {
            user User = customerInfoRepo.GetCustomer(id);
            if (User == null)
            {
                return View("NotFound");
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
        public ActionResult Delete(int id, FormCollection collection)
        {
            user User = customerInfoRepo.GetCustomer(id);
            if (User == null)
            {
                return View("NotFount");
            }
            customerInfoRepo.DelelteCustomer(User);
            customerInfoRepo.save();
            return View("Deleted");
            //try
            //{
            //    // TODO: Add delete logic here
 
            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
