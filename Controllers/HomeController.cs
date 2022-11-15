using FaturaYönetimSistemleri.Models.DB;
using FaturaYönetimSistemleri.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FaturaYönetimSistemleri.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(User user)
        {
            var login = c.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (login != null)
            {
                FormsAuthentication.SetAuthCookie(login.Email, false);

                Session["UserEmail"] = login.Email.ToString();

                return RedirectToAction("Index", "UserPanel");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
          
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var login = c.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);

            if (login != null)
            {
                FormsAuthentication.SetAuthCookie(login.UserName, false);

                Session["UserName"] = login.UserName.ToString();

                return RedirectToAction("Index", "istatistik");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }


    }

}