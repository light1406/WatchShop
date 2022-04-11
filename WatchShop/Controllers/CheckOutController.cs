using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchShop.Models;

namespace WatchShop.Controllers
{
    public class CheckOutController : Controller
    {
        private DbWatchShop db = new DbWatchShop();
        // GET: CheckOut
        public ActionResult Index()
        {
            if (Session["Customer"] == null)
                return Redirect("~/User/Login");
            return View();
        }

        [HttpPost]
        public ActionResult Payment(string Note)
        {
            Customer user = Session["Customer"] as Customer;
            List<CartItem> ShopCart = Session["Cart"] as List<CartItem>;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            Order order = new Order();
            order.Id = new string(Enumerable.Repeat(chars, 10)
            .Select(s => s[random.Next(s.Length)]).ToArray());
            order.Status = "Handling";
            order.Customer = user.Id;
            order.OrderDate = DateTime.Now;
            order.OderDue = DateTime.Now.AddDays(3);
            db.Orders.Add(order);
            foreach(CartItem item in ShopCart)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.Id = new string(Enumerable.Repeat(chars, 10)
            .Select(s => s[random.Next(s.Length)]).ToArray());
                orderDetail.Product = item.Product.Id;
                orderDetail.Quantity = item.Quantity;
                orderDetail.OrderId = order.Id;
                db.OrderDetails.Add(orderDetail);
            }
            db.SaveChanges();
            Session["Cart"] = null;
            return Redirect("~/Home");
        }
    }
}