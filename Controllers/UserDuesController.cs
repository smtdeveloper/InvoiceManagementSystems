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
    public class UserDuesController : Controller
    {
        Context c = new Context();

      
        public ActionResult Index()
        {

            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.Email == userMail).Select(y => y.UserId).FirstOrDefault();

            var fullName = c.Users.Where(x => x.Email == userMail).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
            ViewBag.VfullName = fullName;


            var values = c.Dues.Where(x => x.UserID == userID & x.Status == false).ToList();
            return View(values);

        }

        [HttpGet]
        public ActionResult Payment(int id)
        {

            var value = c.Dues.Find(id);
            return View(value);

        }

        [HttpPost]
        public ActionResult Payment(Dues dues)
        {

            var value = c.Dues.Find(dues.DuesID);

            value.Status = true;

            c.SaveChanges();

            return RedirectToAction("Index");
        }




    }
}