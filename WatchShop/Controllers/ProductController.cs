using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchShop.Models;

namespace WatchShop.Controllers
{
    public class ProductController : Controller
    {
        private DbWatchShop db = new DbWatchShop();
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = db.Products.OrderByDescending(pr => pr.UpdateDate).Take(20).ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult Brand(string Name)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Gender(string Name)
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProductDetail(string Id)
        {
            Product product = db.Products.Where(pr => pr.Id == Id).First();
            return View(product);
        }

        [HttpGet]
        public JsonResult LoadMore(int count)
        {
            List<Product> products = db.Products
                .OrderByDescending(pr => pr.UpdateDate)
                .Skip(count).Take(20).ToList();
            string prs = "";
            foreach (var item in products)
            {
                prs += "<div class='product-item'>"
                         + "<a href = 'product_detail.html'>"
                               + "<div class='discount'>"
                                    + "<span>"+item.Discount+"</span>"
                               + "</div>"
                               + "<div class='image'>"
                                   + "<img src = " +@Url.Content("/Content/image/product/" + item.Avatar) +">"
                               + "</div>"
                               + "<div class='name'>"
                                   + "<span>" + item.Name + "</span>"
                               + "</div>"
                               + "<div class='price'>"
                                   + "<span class='old'>" + item.Price + "%</span>"
                                   + "<span class='new'>" + (item.Price * (1 - item.Discount / 100)) + "%</span>"
                               + "</div>"
                          + "</a>"
                       + "</div>";
            }

            return Json(prs,JsonRequestBehavior.AllowGet);
        }
    }
}