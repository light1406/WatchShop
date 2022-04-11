using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchShop.Models;

namespace WatchShop.Controllers
{
    public class CartController : Controller
    {
        private DbWatchShop db = new DbWatchShop();
        // GET: Cart
        public ActionResult Index()
        {
            List<CartItem> ShopCart = Session["Cart"] as List<CartItem>;
            if (ShopCart == null)
            {
                ViewBag.Message = "Empty";
                return View();
            }
            else
            {
                return View(ShopCart);
            }
        }

        public JsonResult AddToCart(string ProductId, int Quantity)
        {
            Product Product = db.Products.Find(ProductId);
            List<CartItem> ShopCart = Session["Cart"] as List<CartItem>;
            if (ShopCart == null)
            {
                ShopCart = new List<CartItem>();
                ShopCart.Add(new CartItem(Product, Quantity));
                Session["Cart"] = ShopCart;
            }
            else
            {
                bool constrain = false;
                foreach (var CartItem in ShopCart)
                {
                    if (CartItem.Product.Id.Equals(Product.Id))
                    {
                        CartItem.Quantity += Quantity;
                        constrain = true;
                        break;
                    }
                }
                if (!constrain)
                {
                    ShopCart.Add(new CartItem(Product, Quantity));
                }
            }
            return Json(new { message = "Successful", count = ShopCart.Count()},JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveFromCart(string ProductId)
        {
            List<CartItem> ShopCart = Session["Cart"] as List<CartItem>;
            foreach (var CartItem in ShopCart)
            {
                if (CartItem.Product.Id.Equals(ProductId))
                {
                    ShopCart.Remove(CartItem);
                    break;
                }
            }
            var total = ShopCart.Sum(m => m.Product.Price * (1 - m.Product.Discount / 100) * m.Quantity);
            return Json(new { message = "Successful" , count = ShopCart.Count, total = total}, JsonRequestBehavior.AllowGet);
        }
    }
}