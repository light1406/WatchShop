using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchShop.Models;

namespace WatchShop.Controllers
{
    public class LoginController : Controller
    {
        private DbWatchShop db = new DbWatchShop();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string Email, string Password)
        {
            Customer user = db.Customers.Where(u => u.Email.Equals(Email) && u.Password.Equals(Password)).ToList().FirstOrDefault();
            if (user == null)
            {
                ViewBag.Error = "Email or password are uncorrect";
                return View();
            }
            Session["CId"] = user.Id;
            //Session["CName"] = user.Name
            Session["CAvatar"] = user.Avatar;
            return Redirect("~/Home");
        }
    }
}