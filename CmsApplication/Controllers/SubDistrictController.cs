using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CmsApplication.Models;

namespace CmsApplication.Controllers
{
    public class SubDistrictController : Controller
    {
        private cmsEntities db = new cmsEntities();

        // GET: SubDistrict
        //public ActionResult Index()
        //{
        //    var sub_district = db.sub_district.Include(s => s.district);
        //    return View(sub_district.ToList());
        //}

        // GET: SubDistrict/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sub_district sub_district = db.sub_district.Find(id);
            if (sub_district == null)
            {
                return HttpNotFound();
            }
            return View(sub_district);
        }

        // GET: SubDistrict/Create
        public ActionResult Create()
        {
            ViewBag.district_id = new SelectList(db.districts, "district_id", "district_name");
            return View();
        }

        // POST: SubDistrict/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sub_district_id,sub_district_name,district_id")] sub_district sub_district)
        {
            if (ModelState.IsValid)
            {
                db.sub_district.Add(sub_district);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.district_id = new SelectList(db.districts, "district_id", "district_name", sub_district.district_id);
            return View(sub_district);
        }

        // GET: SubDistrict/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sub_district sub_district = db.sub_district.Find(id);
            if (sub_district == null)
            {
                return HttpNotFound();
            }
            ViewBag.district_id = new SelectList(db.districts, "district_id", "district_name", sub_district.district_id);
            return View(sub_district);
        }

        // POST: SubDistrict/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sub_district_id,sub_district_name,district_id")] sub_district sub_district)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sub_district).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Details", new RouteValueDictionary(new { controller = "Districts", action = "Details", Id = sub_district.district_id }));
            }
            ViewBag.district_id = new SelectList(db.districts, "district_id", "district_name", sub_district.district_id);
            return View(sub_district);
        }

        // GET: SubDistrict/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sub_district sub_district = db.sub_district.Find(id);
            if (sub_district == null)
            {
                return HttpNotFound();
            }
            return View(sub_district);
        }

        // POST: SubDistrict/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sub_district sub_district = db.sub_district.Find(id);
            db.sub_district.Remove(sub_district);
            db.SaveChanges();
           // return RedirectToAction("Index");
            return RedirectToAction("Details", new RouteValueDictionary(new { controller = "Districts", action = "Details", Id = sub_district.district_id }));
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
