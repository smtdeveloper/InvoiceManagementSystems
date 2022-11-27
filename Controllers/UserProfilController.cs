using FaturaYönetimSistemleri.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaturaYönetimSistemleri.Controllers
{
    [Authorize]
    public class UserProfilController : Controller
    {
        Context c = new Context();

        // GET: UserProfil
        public ActionResult Index()
        {
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.Email == userMail).Select(y => y.UserId).FirstOrDefault();

            var fullName = c.Users.Where(x => x.Email == userMail).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
            ViewBag.VfullName = fullName;

            var values = c.Users.Where(x => x.UserId == userID & x.IsDelete == false).ToList();
            return View(values);
        }
    }
}