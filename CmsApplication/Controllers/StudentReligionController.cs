using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CmsApplication.Models;
using System.Collections;

namespace CmsApplication.Controllers
{
    public class StudentReligionController : Controller
    {
        private cmsEntities db = new cmsEntities();

        // GET: StudentReligion
        public ActionResult Index()
        {

            Hashtable religions = new Hashtable();

            var religion_list = db.student_religion.ToList();


            foreach (var item in religion_list)
            {
                religions.Add(item.student_religion_id, item.student_religion_name);
            }

            TempData["religions"] = religions;


            //return View(db.student_religion.ToList());
            return View();
        }

        // GET: StudentReligion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student_religion student_religion = db.student_religion.Find(id);
            if (student_religion == null)
            {
                return HttpNotFound();
            }
            return View(student_religion);
        }

        // GET: StudentReligion/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: StudentReligion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "student_religion_id,student_religion_name")] student_religion student_religion)
        {
            if (ModelState.IsValid)
            {
                db.student_religion.Add(student_religion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student_religion);
        }

        // GET: StudentReligion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student_religion student_religion = db.student_religion.Find(id);
            if (student_religion == null)
            {
                return HttpNotFound();
            }
            return View(student_religion);
        }

        // POST: StudentReligion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "student_religion_id,student_religion_name")] student_religion student_religion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_religion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student_religion);
        }

        // GET: StudentReligion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student_religion student_religion = db.student_religion.Find(id);
            if (student_religion == null)
            {
                return HttpNotFound();
            }
            return View(student_religion);
        }

        // POST: StudentReligion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student_religion student_religion = db.student_religion.Find(id);
            db.student_religion.Remove(student_religion);
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
