using System;
using System.Collections;
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
    public class DistrictsController : Controller
    {
        private cmsEntities db = new cmsEntities();

        


        // GET: Districts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hashtable subDistrictHashtable=new Hashtable();
            var aSubDistrict = db.sub_district.Where(b => b.district_id == id);

            foreach (var item in aSubDistrict)
            {
                subDistrictHashtable.Add(item.sub_district_id,item.sub_district_name);
            }
            var dis = db.districts.Single(d => d.district_id == id);
            ViewBag.dis = dis.district_name;
            TempData["subDistrict"] = subDistrictHashtable;

            ViewBag.district_id = new SelectList(db.districts, "district_id", "district_name");
            return View();
            //district district = db.districts.Find(id);
            //if (district == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(district);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details([Bind(Include = "sub_district_id,sub_district_name,district_id")] sub_district sub_district)
        {
            if (ModelState.IsValid)
            {
                db.sub_district.Add(sub_district);
                db.SaveChanges();

                return RedirectToAction("Details", new RouteValueDictionary(new { controller = "Districts", action = "Details", Id = sub_district.district_id }));
              //  return RedirectToAction("Index");
            }

            ViewBag.district_id = new SelectList(db.districts, "district_id", "district_name", sub_district.district_id);
            return View(sub_district);
        }

        // GET: Districts/Create
        //public ActionResult Create()
        //{
        //    ViewBag.division_id = new SelectList(db.divisions, "division_id", "division_name");
        //    return View();
        //}

        // POST: Districts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "district_id,district_name,division_id")] district district)
        {
            if (ModelState.IsValid)
            {
                db.districts.Add(district);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.division_id = new SelectList(db.divisions, "division_id", "division_name", district.division_id);
            return View(district);
        }

        // GET: Districts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            district district = db.districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            ViewBag.division_id = new SelectList(db.divisions, "division_id", "division_name", district.division_id);

           
            return View(district);
           
        }

        // POST: Districts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "district_id,district_name,division_id")] district district)
        {
            if (ModelState.IsValid)
            {
                db.Entry(district).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Details", new RouteValueDictionary(new { controller = "Divisions", action = "Details", Id = district.division_id }));

            }
            ViewBag.division_id = new SelectList(db.divisions, "division_id", "division_name", district.division_id);
            return View(district);
           
        }

        // GET: Districts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            district district = db.districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        // POST: Districts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            district district = db.districts.Find(id);
            db.districts.Remove(district);
            db.SaveChanges();

           // return RedirectToAction("Index");
            return RedirectToAction("Details", new RouteValueDictionary(new { controller = "Divisions", action = "Details", Id = district.division_id }));
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
