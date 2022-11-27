using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaturaYönetimSistemleri.Controllers
{
    [Authorize]
    public class UserContactController : Controller
    {
        // GET: UserContact
        public ActionResult Index()
        {
            return View();
        }
    }
}