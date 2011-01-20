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
using System.Net;
using System.IO;
using englishsnsVS10.SystemInterfaces;

namespace englishsnsVS10.Controllers
{

    [HandleError]
    public class AccountController : Controller
    {
        ICustomerInfoRepo customerInfoRepo { get; set; }
        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        ILoginValidation validation;

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
            if (Request.IsAuthenticated == false)
            {
                string note = GetRandomString(10);
                Response.Cookies["loginnote"].Value = note;
                Response.Cookies["loginnote"].Expires = DateTime.Now.AddHours(1.0);
                return Redirect("http://jaccount.sjtu.in/index.php?reurl=http://localhost:12183/account/logon&authnote=" + note);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string ticket)
        {
            ticket = Server.UrlEncode(ticket);
            string mark = Request.Cookies["loginnote"].Value;
       
            if (validation.validate(mark, ticket))
            {
                if (customerInfoRepo.GetCustomer(model.uid) == null)
                {
                    user user = new user();
                    user.username = model.uid;
                    user.name = model.chinesename;
                    customerInfoRepo.AddCustomer(user);
                    customerInfoRepo.save();

                }
                signin(model.uid);              
            }
            return RedirectToAction("Index", "Home");
        }

        private void signin(string id)
        {
            FormsService.SignIn(id, false);
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
                int temp = ran.Next('a', 'z');
                while ('a' > temp || temp > 'z')
                {
                    temp = ran.Next();
                }
                result += (char)temp;
            }
            return result;
        }


    }

    //interface ILoginValidation
    //{
    //    bool validate(string text, string ticket);
    //}

    //public class RemoteValidate : ILoginValidation
    //{
    //    public bool validate(string text, string ticket)
    //    {
    //        string url = "http://jaccount.sjtu.in/validation.php?key=" + text + "&ticket=" + ticket;
    //        HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
    //        string result;
    //        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
    //        {
    //            StreamReader reader = new StreamReader(response.GetResponseStream());
    //            result = reader.ReadToEnd();
    //        }

    //        if (result == "1")
    //        {
    //            return true;
    //        }
    //        else
    //            return false;
    //    }


    //}

    //public class LocalValidate : ILoginValidation
    //{
    //    public bool validate(string text, string ticket)
    //    {
    //        System.IO.StreamReader sr = new System.IO.StreamReader(@"..\public.key");
    //        string publickey = sr.ReadToEnd();
    //        sr.Close();

    //        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

    //        rsa.ImportParameters(ConvertFromPemPrivateKey(publickey));

    //        var result = System.Text.Encoding.ASCII.GetString(rsa.Decrypt(System.Text.Encoding.ASCII.GetBytes(ticket), false));
    //        return true;
    //    }

    //    private RSAParameters ConvertFromPemPublicKey(string pemFileConent)
    //    {
    //        if (string.IsNullOrEmpty(pemFileConent))
    //        {
    //            throw new ArgumentNullException("pemFileConent", "This arg cann't be empty.");
    //        }
    //        pemFileConent = pemFileConent.Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", "").Replace("\n", "").Replace("\r", "");
    //        byte[] keyData = Convert.FromBase64String(pemFileConent);
    //        if (keyData.Length < 162)
    //        {
    //            throw new ArgumentException("pem file content is incorrect.");
    //        }
    //        byte[] pemModulus = new byte[128];
    //        byte[] pemPublicExponent = new byte[3];
    //        Array.Copy(keyData, 29, pemModulus, 0, 128);
    //        Array.Copy(keyData, 159, pemPublicExponent, 0, 3);
    //        RSAParameters para = new RSAParameters();
    //        para.Modulus = pemModulus;
    //        para.Exponent = pemPublicExponent;
    //        return para;
    //    }

    //    private RSAParameters ConvertFromPemPrivateKey(string pemFileConent)
    //    {
    //        if (string.IsNullOrEmpty(pemFileConent))
    //        {
    //            throw new ArgumentNullException("pemFileConent", "This arg cann‘t be empty.");
    //        }
    //        pemFileConent = pemFileConent.Replace("-----BEGIN RSA PRIVATE KEY-----", "").Replace("-----END RSA PRIVATE KEY-----", "").Replace("\n", "").Replace("\r", "");
    //        byte[] keyData = Convert.FromBase64String(pemFileConent);
    //        if (keyData.Length < 609)
    //        {
    //            throw new ArgumentException("pem file content is incorrect.");
    //        }

    //        int index = 11;
    //        byte[] pemModulus = new byte[128];
    //        Array.Copy(keyData, index, pemModulus, 0, 128);

    //        index += 128;
    //        index += 2;//141
    //        byte[] pemPublicExponent = new byte[3];
    //        Array.Copy(keyData, index, pemPublicExponent, 0, 3);

    //        index += 3;
    //        index += 4;//148
    //        byte[] pemPrivateExponent = new byte[128];
    //        Array.Copy(keyData, index, pemPrivateExponent, 0, 128);

    //        index += 128;
    //        index += ((int)keyData[index + 1] == 64 ? 2 : 3);//279
    //        byte[] pemPrime1 = new byte[64];
    //        Array.Copy(keyData, index, pemPrime1, 0, 64);

    //        index += 64;
    //        index += ((int)keyData[index + 1] == 64 ? 2 : 3);//346
    //        byte[] pemPrime2 = new byte[64];
    //        Array.Copy(keyData, index, pemPrime2, 0, 64);

    //        index += 64;
    //        index += ((int)keyData[index + 1] == 64 ? 2 : 3);//412/413
    //        byte[] pemExponent1 = new byte[64];
    //        Array.Copy(keyData, index, pemExponent1, 0, 64);

    //        index += 64;
    //        index += ((int)keyData[index + 1] == 64 ? 2 : 3);//479/480
    //        byte[] pemExponent2 = new byte[64];
    //        Array.Copy(keyData, index, pemExponent2, 0, 64);

    //        index += 64;
    //        index += ((int)keyData[index + 1] == 64 ? 2 : 3);//545/546
    //        byte[] pemCoefficient = new byte[64];
    //        Array.Copy(keyData, index, pemCoefficient, 0, 64);

    //        RSAParameters para = new RSAParameters();
    //        para.Modulus = pemModulus;
    //        para.Exponent = pemPublicExponent;
    //        para.D = pemPrivateExponent;
    //        para.P = pemPrime1;
    //        para.Q = pemPrime2;
    //        para.DP = pemExponent1;
    //        para.DQ = pemExponent2;
    //        para.InverseQ = pemCoefficient;
    //        return para;
    //    }
    //}

    //public class ValidationProxy : ILoginValidation
    //{
    //    ILoginValidation remote;
    //    ILoginValidation local;

    //    public bool validate(string text, string ticket)
    //    {
    //        remote = new RemoteValidate();
    //        bool result;
    //        try
    //        {
    //            result = remote.validate(text, ticket);
    //        }
    //        catch
    //        {
    //            local = new LocalValidate();
    //            result = local.validate(text, ticket);
    //        }

    //        return result;
    //    }
    //}
}
