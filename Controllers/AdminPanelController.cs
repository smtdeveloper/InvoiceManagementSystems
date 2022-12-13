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
    public class AdminPanelController : Controller
    {

        Context c = new Context();

        // GET: AdminPanel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IncomingMessage()
        {
            var mail = User.Identity.Name;
            var values = c.Messages.Where(x => x.Recipient == mail && x.IsDelete == false).ToList();
            return View(values);

        }

        public ActionResult OutgoingMessage()
        {
            var mail = User.Identity.Name;
            var values = c.Messages.Where(x => x.Sender == mail && x.IsDelete == false).ToList();
            return View(values);

        }

        public ActionResult MesssageDetail(int id)
        {
            var values = c.Messages.Where(x => x.ID == id).ToList();
            return View(values);
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

           
            message.Sender = "Admin";
            message.IsDelete = false;


            message.Date = DateTime.Parse(DateTime.Now.ToString());

            Thread.Sleep(2000);

            c.Messages.Add(message);
            c.SaveChanges();
            return RedirectToAction("OutgoingMessage");
        }

        [HttpPost]
        public ActionResult MessageSoftDelete(int id)
        {
            var value = c.Messages.Find(id);


            if (value.IsDelete)
            {
                value.IsDelete = false;
            }
            else
            {
                value.IsDelete = true;
            }
            c.SaveChanges();
            return RedirectToAction("IncomingMessage");
        }

    }
}