using FaturaYönetimSistemleri.Models.DB;
using FaturaYönetimSistemleri.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace FaturaYönetimSistemleri.Controllers
{
    [Authorize]
    public class DuesController : Controller
    {
        Context c = new Context();

        // GET: Dues
        public ActionResult Index(int page = 1)
        {
            var values = c.Dues.ToList().ToPagedList(page, 20);
            return View(values);
        }

        [HttpPost]
        public ActionResult Index(Dues dues)
        {

            c.Dues.Add(dues);
            c.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult DuesUpdate(int id)
        {
            List<SelectListItem> duess = (from x in c.Users.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.FirstName + "  " + x.LastName,
                                              Value = x.UserId.ToString()
                                          }).ToList();
            ViewBag.VUsers = duess;


            var value = c.Dues.Find(id);
            return View("DuesUpdate", value);
        }

        [HttpPost]
        public ActionResult DuesUpdate(Dues dues)
        {
            var value = c.Dues.Find(dues.DuesID);

            value.Status = dues.Status;
            value.Price = dues.Price;
            value.Description = dues.Description;
            value.Date = dues.Date;
            
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult DuesAdd()
        {
            List<SelectListItem> users = (from x in c.Users.Where(x => x.IsDelete == false).ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.FirstName + "  " + x.LastName,
                                              Value = x.UserId.ToString()
                                          }).ToList();
            ViewBag.VUsers = users;
            return View();

        }

        [HttpPost]
        public ActionResult DuesAdd(Dues dues)
        {

            c.Dues.Add(dues);
            c.SaveChanges();

            Thread.Sleep(3000);

            return RedirectToAction("DuesAdd");

        }



        public ActionResult DuesStatus(int id)
        {
            var value = c.Dues.Find(id);

            if (value.Status)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }

            c.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}