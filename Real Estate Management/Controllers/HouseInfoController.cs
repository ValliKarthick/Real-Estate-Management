using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Real_Estate_Management.Models;

namespace Real_Estate_Management.Controllers
{
    public class HouseInfoController : Controller
    {
        private HouseContext db = new HouseContext();
        private HouseInformationsEntities db2 = new HouseInformationsEntities();

        List<SelectListItem> Housetypes = new List<SelectListItem>()
            {
            new SelectListItem{ Text="apartments", Value = "apartments" },
            new SelectListItem{ Text="villa", Value = "villa" },
            new SelectListItem{ Text="independent house", Value = "independent house" },
            new SelectListItem{ Text="pent house", Value = "pent house" },
            new SelectListItem{ Text="row house", Value = "row house" },
            new SelectListItem{ Text="duplex", Value = "duplex" },
            new SelectListItem{ Text="studio apartment", Value = "studio apartment" },
            new SelectListItem{ Text="commercial space", Value = "commercial space" },
            new SelectListItem{ Text="plot", Value = "plot" },
            };
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Modify()
        {
            return View(db.HouseInformations.ToList());
        }

        [Route("ViewDetails/info")]
        public ActionResult Index()
        {
            ViewBag.Hello = "Welcome";
            //ViewBag.UserName = Session["UserName"].ToString();
            return View(db.HouseInformations.ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseInformation houseInformation = db.HouseInformations.Find(id);
            if (houseInformation == null)
            {
                return HttpNotFound();
            }
            return View(houseInformation);
        }

        public ActionResult Create()
        {
            ViewBag.HouseTypes = Housetypes;
            //ViewBag.HouseTypes = db2.HouseTypes.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SearchId,BrokerId,HouseType,Location,SquareFeet,SaleType,Price,ContactNumber")] HouseInformation houseInformation)
        {
            if (ModelState.IsValid)
            {
                houseInformation.UpdatedDate = DateTime.UtcNow;
                db.HouseInformations.Add(houseInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(houseInformation);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseInformation houseInformation = db.HouseInformations.Find(id);
            if (houseInformation == null)
            {
                return HttpNotFound();
            }
            //ViewBag.HouseTypes = db2.HouseTypes.ToList();
            ViewBag.HouseTypes = Housetypes;
            return View(houseInformation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SearchId,BrokerId,HouseType,Location,SquareFeet,SaleType,Price,ContactNumber")] HouseInformation houseInformation)
        {
            if (ModelState.IsValid)
            {
                houseInformation.UpdatedDate = DateTime.UtcNow;
                db.Entry(houseInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(houseInformation);
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseInformation houseInformation = db.HouseInformations.Find(id);
            if (houseInformation == null)
            {
                return HttpNotFound();
            }
            return View(houseInformation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HouseInformation houseInformation = db.HouseInformations.Find(id);
            db.HouseInformations.Remove(houseInformation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
