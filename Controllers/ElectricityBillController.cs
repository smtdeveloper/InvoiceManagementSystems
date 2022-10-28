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
    public class ElectricityBillController : Controller
    {
        Context c = new Context();

        // GET: ElectricityBill
        public ActionResult Index(int page = 1)
        {
            var values = c.ElectricityBills.ToList().ToPagedList(page, 20);
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
            return View();

        }

        [HttpPost]
        public ActionResult ElectricityBillAdd(ElectricityBill electricityBill)
        {

            c.ElectricityBills.Add(electricityBill);
            c.SaveChanges();

            return RedirectToAction("Index");

        }


    }
}