using FaturaYönetimSistemleri.Models.DB;
using FaturaYönetimSistemleri.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace FaturaYönetimSistemleri.Controllers
{
    [Authorize]
    public class UserPanelController : Controller
    {
        Context c = new Context();

        // GET: UserPanel
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewMessage() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            var mail = User.Identity.Name;

            message.Recipient = "Admin";
            message.Sender = mail;

            message.Status = false;
            message.IsDelete = false;


            message.Date = DateTime.Parse(DateTime.Now.ToString());

            Thread.Sleep(2000);

            c.Messages.Add(message);
            c.SaveChanges();
            return RedirectToAction("OutgoingMessage");
        }

        public ActionResult IncomingMessage()
        {
            var mail = User.Identity.Name;
            var values = c.Messages.Where(x => x.Recipient == mail).ToList();
            return View(values);

        }

        public ActionResult OutgoingMessage()
        {
            var mail = User.Identity.Name;
            var values = c.Messages.Where(x => x.Sender == mail).ToList();
            return View(values);

        }

        public ActionResult MesssageDetail(int id)
        {
            var values = c.Messages.Where(x => x.ID == id).ToList();
            return View(values);
        }


    }

}