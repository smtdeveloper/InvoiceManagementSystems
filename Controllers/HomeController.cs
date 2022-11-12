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

                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
          
        }

        [HttpPost]
        public ActionResult AdminLogin(User user)
        {
            var login = c.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (login != null)
            {
                FormsAuthentication.SetAuthCookie(login.Email, false);

                Session["UserEmail"] = login.Email.ToString();

                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }


    }

}