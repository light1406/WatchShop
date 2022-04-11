using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchShop.Models;

namespace WatchShop.Controllers
{
    public class UserController : Controller
    {
        private DbWatchShop db = new DbWatchShop();
        // GET: User
        public ActionResult Index()
        {
            Customer user = Session["Customer"] as Customer;
            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email, string Password)
        {
            Customer user = db.Customers.Where(u => u.Email.Equals(Email) && u.Password.Equals(Password)).ToList().FirstOrDefault();
            if (user == null)
            {
                ViewBag.Error = "Email or password are uncorrect";
                return View();
            }
            Session["Customer"] = user;
            return Redirect("~/Home");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer Customer, HttpPostedFileBase Avatar)
        {
            var check = db.Customers.Where(cs => cs.Email.Equals(Customer.Email));
            if (check == null)
            {
                ViewBag.Error = "Email is existed";
                return View();
            }
            string FileName = Path.GetFileName(Avatar.FileName);
            string path = Path.Combine(Server.MapPath("~/Content/image/avatar"), FileName);
            Avatar.SaveAs(path);
            Customer.Avatar = FileName;
            db.Customers.Add(Customer);
            db.SaveChanges();
            return RedirectToAction("/Login");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}