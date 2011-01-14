using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using englishsnsVS10.Models;
using englishsnsVS10.datacontext;
using englishsnsVS10.DAOimpl;
using System.Security.Cryptography;

namespace englishsnsVS10.Controllers
{

    [HandleError]
    public class AccountController : Controller
    {
        public CustomerInfoRepo customerInfoRepo { get; set; }
        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        Random ran = new Random();
        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult LogOn()
        {
            //return View();
            //string note = GetRandomString(10);
            //Response.Cookies["loginnote"].Value = note;
           // Response.Cookies["loginnote"].Expires = DateTime.Now.AddHours(1.0);
            return Redirect("http://jaccount.sjtu.in/index.php?reurl=http://localhost:12183/account/logon");
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            //SHA1 sha = new SHA1Managed();

            //string returnauth = Request.Cookies["loginnote"].Value;
            //var result = sha.ComputeHash(System.Text.Encoding.ASCII.GetBytes(returnauth));

            //System.IO.StreamReader sr = new System.IO.StreamReader(Server.MapPath(@"..\public.key"));
            //string publickey = sr.ReadToEnd();
           // sr.Close();

            //RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            //rsa.ImportParameters(ConvertFromPemPublicKey(publickey));

            //var temp = rsa.ToXmlString(false);
            //string temp = rsa.ToXmlString(true);
            //rsa.FromXmlString(publickey);
            //RSAParameters para = new RSAParameters();
            //var result = System.Text.Encoding.ASCII.GetString(rsa.Decrypt(System.Text.Encoding.ASCII.GetBytes(auth), false));
         
            if (customerInfoRepo.GetCustomer(model.uid).Count() == 0)
            {
                user user = new user();
                user.username = model.uid;
                user.name = model.chinesename;
                customerInfoRepo.AddCustomer(user);
                customerInfoRepo.save();
           
            }
            
            FormsService.SignIn(model.uid, false);
            return RedirectToAction("Index", "Home");
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff()
        {
            FormsService.SignOut();

            return RedirectToAction("Index", "Home");
        }

        // **************************************
        // URL: /Account/Register
        // **************************************

        public ActionResult Register()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePassword
        // **************************************

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        private string GetRandomString(int size)
        {
            string result = "";

            for (int i = 1; i < size; i++)
            {
                int temp = ran.Next(100);
                while ( 'a' > temp || temp > 'z' )
                {
                    temp = ran.Next();
                }
                result += (char)temp;
            }
            return result;
        }

        public static RSAParameters ConvertFromPemPublicKey(string pemFileConent)
        {
            if (string.IsNullOrEmpty(pemFileConent))
            {
                throw new ArgumentNullException("pemFileConent", "This arg cann't be empty.");
            }
            pemFileConent = pemFileConent.Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", "").Replace("\n", "").Replace("\r", "");
            byte[] keyData = Convert.FromBase64String(pemFileConent);
            if (keyData.Length < 162)
            {
                throw new ArgumentException("pem file content is incorrect.");
            }
            byte[] pemModulus = new byte[128];
            byte[] pemPublicExponent = new byte[3];
            Array.Copy(keyData, 29, pemModulus, 0, 128);
            Array.Copy(keyData, 159, pemPublicExponent, 0, 3);
            RSAParameters para = new RSAParameters();
            para.Modulus = pemModulus;
            para.Exponent = pemPublicExponent;
            return para;
        }
    }
}
