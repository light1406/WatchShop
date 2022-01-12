using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WatchShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Filter(string Category, string Gender)
        {
            return View();
        }

        public ActionResult ProductDetail(string Id)
        {
            return View();
        }
    }
}