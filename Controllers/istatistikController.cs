using FaturaYönetimSistemleri.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaturaYönetimSistemleri.Controllers
{
    [Authorize]
    public class istatistikController : Controller
    {
        Context c = new Context();

        // GET: istatistik
        public ActionResult Index()
        {

            //var users = (from x in c.Users select x.IsDelete == false).Count().ToString();
            var users = c.Users.Where(x => x.IsDelete == false).Count().ToString();
            ViewBag.users = users;

            var WaterBills = c.WaterBills.Where(x => x.WaterBillStatus == false).Count().ToString();
            ViewBag.WaterBills = WaterBills;

            //var NaturalGasBills = (from x in c.NaturalGasBills select x.NaturalGasBillStatus == false ).Count().ToString();
            var NaturalGasBills = c.WaterBills.Where(x => x.WaterBillStatus == false).Count().ToString();
            ViewBag.NaturalGasBills = NaturalGasBills;

            var ElectricityBills = c.ElectricityBills.Where(x => x.ElectricityBillStatus == false).Count().ToString();
            ViewBag.ElectricityBills = ElectricityBills;


            var values = c.Todos.Where(x => x.IsDelete == false).ToList();

            return View(values);

          
        }
    }
}