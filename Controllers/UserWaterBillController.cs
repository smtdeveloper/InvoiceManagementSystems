using FaturaYönetimSistemleri.Models.DB;
using FaturaYönetimSistemleri.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaturaYönetimSistemleri.Controllers
{
    public class UserWaterBillController : Controller
    {
        Context c = new Context();

        // GET: UserElectricityBill
        public ActionResult Index()
        {
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.Email == userMail).Select(y => y.UserId).FirstOrDefault();

            var fullName = c.Users.Where(x => x.Email == userMail).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
            ViewBag.VfullName = fullName;

            var values = c.WaterBills.Where(x => x.UserID == userID & x.WaterBillStatus == false).ToList();
            return View(values);

        }

        [HttpGet]
        public ActionResult Payment(int id)
        {

            var value = c.WaterBills.Find(id);
            return View(value);

        }

        [HttpPost]
        public ActionResult Payment(WaterBill waterBill)
        {

            var value = c.WaterBills.Find(waterBill.WaterBillID);

            value.WaterBillStatus = true;

            c.SaveChanges();

            return RedirectToAction("Index");
        }




    }
}