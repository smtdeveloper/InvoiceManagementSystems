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
    public class NaturalGasBillController : Controller
    {

        Context c = new Context();

        // GET: NaturalGasBill
        public ActionResult Index(int page = 1)
        {
            var values = c.NaturalGasBills.ToList().ToPagedList(page, 20);
            return View(values);
        }

        [HttpGet]
        public ActionResult NaturalGasBillAdd()
        {
            return View();

        }

        [HttpPost]
        public ActionResult NaturalGasBillAdd(NaturalGasBill naturalGasBill)
        {

            c.NaturalGasBills.Add(naturalGasBill);
            c.SaveChanges();

            return RedirectToAction("Index");

        }

    }
}