using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace TCMI.Admin.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Login")]
        public ActionResult LoginPost(string username, string pass)
        {
            
            var response = Request["g-recaptcha-response"];
            if (!response.ToString().Equals(string.Empty))
            {
                if (username.Equals("admin") && pass.Equals("admin"))
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    return RedirectToAction("Index", "Prayer");
                }
                else
                {

                    ViewBag.Message = MessageString("Invalid User or Password!");
                }

            }
            else
            {
                ViewBag.Message = MessageString("Check captcha!");
            }

            return View();
        }

        private string MessageString(string msg)
        {
            string returnValue = string.Empty;
            returnValue = "<div class=\"alert alert-danger\"> <strong>Message : </strong>" + msg + "</div>";
            return returnValue;
        }
    }
}
