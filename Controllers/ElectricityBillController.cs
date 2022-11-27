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
    public class ElectricityBillController : Controller
    {
        Context c = new Context();

        public ActionResult ElectricityBillPDF()
        {
            var values = c.ElectricityBills.ToList();
            return View(values);

        }

        // GET: ElectricityBill
        public ActionResult Index()
        {
            var values = c.ElectricityBills.ToList();
            return View(values);
        }

        [HttpPost]
        public ActionResult Index(ElectricityBill electricityBill)
        {

            c.ElectricityBills.Add(electricityBill);
            c.SaveChanges();

            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult ElectricityBillAdd()
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
        public ActionResult ElectricityBillAdd(ElectricityBill electricityBill)
        {

            c.ElectricityBills.Add(electricityBill);
            c.SaveChanges();

            Thread.Sleep(3000);

            return RedirectToAction("ElectricityBillAdd");

        }


    }
}