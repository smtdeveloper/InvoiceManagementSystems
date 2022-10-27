using FaturaYönetimSistemleri.Models.DB;
using FaturaYönetimSistemleri.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaturaYönetimSistemleri.Controllers
{
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
    }
}