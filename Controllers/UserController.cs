using FaturaYönetimSistemleri.Models.DB;
using FaturaYönetimSistemleri.Models.Entities;
using System.Linq;
using System.Web.Mvc;

namespace FaturaYönetimSistemleri.Controllers
{
    public class UserController : Controller
    {
        Context c = new Context();

        // GET: User
        public ActionResult Index()
        {
            var values = c.Users.Where(x => x.IsDelete == false).ToList();
            return View(values);
        }

        [HttpPost]
        public ActionResult Index(User user)
        {

            c.Users.Add(user);
            c.SaveChanges();

            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult UserAdd()
        {
            return View();

        }

        [HttpPost]
        public ActionResult UserAdd(User user)
        {

            c.Users.Add(user);
            c.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult UserDetay(int id)
        {
            var values = c.Apartments.Where(x => x.UserId == id).ToList();

            var userName = c.Users.Where(x => x.UserId == id).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
            ViewBag.VuserName = userName;

            return View(values);

        }

        public ActionResult UserElectricityBill(int id)
        {
            var values = c.ElectricityBills.Where(x => x.UserID == id).ToList();

            var userName = c.Users.Where(x => x.UserId == id).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
            ViewBag.VuserName = userName;

            return View(values);

        }
        public ActionResult UserNaturalGasBill(int id)
        {
            var values = c.NaturalGasBills.Where(x => x.UserID == id).ToList();

            var userName = c.Users.Where(x => x.UserId == id).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
            ViewBag.VuserName = userName;

            return View(values);

        }
        public ActionResult UserWaterBill(int id)
        {
            var values = c.WaterBills.Where(x => x.UserID == id).ToList();

            var userName = c.Users.Where(x => x.UserId == id).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
            ViewBag.VuserName = userName;

            return View(values);

        }

        public ActionResult UserUpdate(int id)
        {
            var value = c.Users.Find(id);

            return View("UserUpdate", value);


        }

        [HttpPost]
        public ActionResult UserUpdated(User user)
        {
            var value = c.Users.Find(user.UserId);

            value.FirstName = user.FirstName;
            value.LastName = user.LastName;
            value.Email = user.Email;
            value.Password = user.Password;

            value.TCNo = user.TCNo;
            value.Phone = user.Phone;

            value.ImageURL = user.ImageURL;
            value.CarsPlate = user.CarsPlate;

            value.ApartmentOwner = user.ApartmentOwner;
            value.IsDelete = user.IsDelete;
            value.ApartmentID = user.ApartmentID;


            c.SaveChanges();

            return RedirectToAction("Index");


        }

    }
}