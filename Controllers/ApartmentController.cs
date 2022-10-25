using FaturaYönetimSistemleri.Models.DB;
using FaturaYönetimSistemleri.Models.Entities;
using PagedList;
using System.Linq;
using System.Web.Mvc;


namespace FaturaYönetimSistemleri.Controllers
{
    public class ApartmentController : Controller
    {
        Context c = new Context();

        // GET: Apartment
        public ActionResult Index(int page = 1)
        {
            //var values = c.Apartments.ToList().ToPagedList(page, 20);
            var values = c.Apartments.ToList().ToPagedList(page , 20 );
            return View(values);
        }

        [HttpPost]
        public ActionResult Index(Apartment apartment)
        {

            c.Apartments.Add(apartment);
            c.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult ApartmentUpdate(int id)
        {
            var value = c.Apartments.Find(id);
            return View("ApartmentUpdate", value);
        }

        [HttpPost]
        public ActionResult ApartmentUpdate(Apartment apartment) 
        {
            var value = c.Apartments.Find(apartment.ApartmentId);

            value.Status = apartment.Status;
            value.UserId = apartment.UserId;
            
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ApartmentDetay(int id)
        {
            var values = c.Users.Where(x => x.ApartmentID == id).ToList();
            return View(values);

        }

    }
}