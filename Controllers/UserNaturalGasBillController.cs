using FaturaYönetimSistemleri.Models.DB;
using FaturaYönetimSistemleri.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaturaYönetimSistemleri.Controllers
{
    [Authorize]
    public class UserNaturalGasBillController : Controller
    {
        Context c = new Context();

        // GET: UserElectricityBill
        public ActionResult Index()
        {
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.Email == userMail).Select(y => y.UserId).FirstOrDefault();

            var fullName = c.Users.Where(x => x.Email == userMail).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
            ViewBag.VfullName = fullName;

            var values = c.NaturalGasBills.Where(x => x.UserID == userID & x.NaturalGasBillStatus == false).ToList();
            return View(values);

        }

        [HttpGet]
        public ActionResult Payment(int id)
        {

            var value = c.NaturalGasBills.Find(id);
            return View(value);

        }

        [HttpPost]
        public ActionResult Payment(NaturalGasBill naturalGasBill)
        {

            var value = c.NaturalGasBills.Find(naturalGasBill.NaturalGasBillID);

            value.NaturalGasBillStatus = true;

            c.SaveChanges();

            return RedirectToAction("Index");
        }




    }
}