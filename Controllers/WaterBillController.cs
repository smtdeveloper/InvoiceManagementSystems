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
    public class WaterBillController : Controller
    {
        // GET: WaterBill
        Context c = new Context();

        public ActionResult Index(int page = 1)
        {
            var values = c.WaterBills.ToList().ToPagedList(page, 20);
            return View(values);
        }


        [HttpGet]
        public ActionResult WaterBillAdd()
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
        public ActionResult WaterBillAdd(WaterBill waterBill)
        {

            c.WaterBills.Add(waterBill);
            c.SaveChanges();

            return RedirectToAction("Index");

        }



    }
}