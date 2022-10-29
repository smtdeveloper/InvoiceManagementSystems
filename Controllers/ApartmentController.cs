using FaturaYönetimSistemleri.Models.DB;
using FaturaYönetimSistemleri.Models.Entities;
using PagedList;
using System.Collections.Generic;
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

            List<SelectListItem> users = (from x in c.Users.Where(x => x.IsDelete == false).ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.FirstName + "  " + x.LastName,
                                              Value = x.UserId.ToString()
                                          }).ToList();
            ViewBag.VUsers = users;


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

        public ActionResult ApartmentClear(int id)
        {
            var value = c.Apartments.Find(id);

            
                value.UserId =  null;
                value.Status = false;


            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}