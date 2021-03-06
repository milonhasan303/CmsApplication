﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CmsApplication.Models;
using System.Collections;

namespace CmsApplication.Controllers
{
    public class DivisionsController : Controller
    {
        private cmsEntities db = new cmsEntities();

        // GET: Divisions
        public ActionResult Index()
        {
            Hashtable divisions = new Hashtable();

            var divsion_list = db.divisions.ToList();

            foreach (var item in divsion_list)
            {
                divisions.Add(item.division_id,item.division_name);


                //ViewData["div"] = divisions[item.division_id];
                
            }
            TempData["divisions"] = divisions;
            
            //string value1 = (string)hashtable[300];
            return View();
          //  return View(db.divisions.ToList());
        }

        // GET: Divisions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Hashtable districtHashtable=new Hashtable();
            var aDistrict = db.districts.Where(d => d.division_id == id).ToList();

            foreach (var item in aDistrict)
            {
                districtHashtable.Add(item.district_id,item.district_name);
                
            }
            var div = db.divisions.Single(m => m.division_id == id);
            ViewBag.div = div.division_name;
            TempData["district"] = districtHashtable;

            

            //division division = db.divisions.Find(id);
            //if (division == null)
            //{
            //    return HttpNotFound();
            //}
            ViewBag.division_id = new SelectList(db.divisions, "division_id", "division_name");
           
            return View();
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details([Bind(Include = "district_id,district_name,division_id")] district district)
        {
            if (ModelState.IsValid)
            {
                db.districts.Add(district);
                db.SaveChanges();
                //return RedirectToAction("Index");
               // return View("Details", new { id = district.division_id });
                return RedirectToAction("Details", new RouteValueDictionary(new { controller = "Divisions", action = "Details", Id = district.division_id }));
            }
            
            ViewBag.division_id = new SelectList(db.divisions, "division_id", "division_name", district.division_id);
            
            return View(district);
        }




        // GET: Divisions/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Divisions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "division_id,division_name")] division division)
        {
            if (ModelState.IsValid)
            {
                db.divisions.Add(division);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(division);
        }

        // GET: Divisions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            division division = db.divisions.Find(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

        // POST: Divisions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "division_id,division_name")] division division)
        {
            if (ModelState.IsValid)
            {
                db.Entry(division).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(division);
        }

        // GET: Divisions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            division division = db.divisions.Find(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

        // POST: Divisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            division division = db.divisions.Find(id);
            db.divisions.Remove(division);
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
