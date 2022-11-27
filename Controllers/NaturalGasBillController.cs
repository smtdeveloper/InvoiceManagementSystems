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
        public ActionResult NaturalGasBillAdd(NaturalGasBill naturalGasBill)
        {

            c.NaturalGasBills.Add(naturalGasBill);
            c.SaveChanges();

            Thread.Sleep(3000);

            return RedirectToAction("NaturalGasBillAdd");

        }

    }
}