using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchShop.Models;

namespace WatchShop.Controllers
{
    public class HomeController : Controller
    {
        private DbWatchShop db = new DbWatchShop();
        // GET: Home
        public ActionResult Index()
        {
            List<Brand> rs = db.Brands.ToList();
            return View(rs);
        }
    }
}