using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchShop.Models;

namespace WatchShop.Controllers
{
    public class RegisterController : Controller
    {
        private DbWatchShop db = new DbWatchShop();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Customer Customer, HttpPostedFileBase Avatar)
        {
            //if (!ModelState.IsValid)
            //    return View();
            var check = db.Customers.Where(cs => cs.Email.Equals(Customer.Email));
            if (check == null)
            {
                ViewBag.Error = "Email is existed";
                return View();
            }
            string FileName = Path.GetFileName(Avatar.FileName);
            string path = Path.Combine(Server.MapPath("~/Content/image/avatar"), FileName);
            Avatar.SaveAs(path);
            Customer.Gender = "Nam";
            Customer.FullName = "A";
            Customer.Avatar = FileName;
            db.Customers.Add(Customer);
            db.SaveChanges();
            return Redirect("~/Login");
        }
    }
}