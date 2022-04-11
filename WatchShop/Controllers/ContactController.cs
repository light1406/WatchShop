using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WatchShop.Models;

namespace WatchShop.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendContact(string Name, string Email, string Message)
        {
            //if (ModelState.IsValid)
            //{
            //    using (var context = new DbWatchShopEntities())
            //    {
            //        context.Contacts.Add(new Contact
            //        {
            //            Id = new Random().Next(10000),
            //            Name = Name,
            //            Email = Email,
            //            Message = Message
            //        });
            //        context.SaveChanges();
            //    }
            //    string from = "hk1dotnet@gmail.com";
            //    string password = "hk1dotnet@k19";
            //    var mail = new SmtpClient("smtp.gmail.com", 25)
            //    {
            //        Credentials = new NetworkCredential(from, password),
            //        EnableSsl = true
            //    };

            //    var message = new MailMessage();
            //    message.From = new MailAddress(from);
            //    message.To.Add(new MailAddress(Email));
            //    message.Subject = "Reply to " + Name;
            //    message.Body = "We got your message: "+Message+"\nWe will reply your contact soon";
            //    mail.Send(message);
            //}
            return View("Index");

        }
    }
}