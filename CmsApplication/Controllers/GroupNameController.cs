using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CmsApplication.Models;

namespace CmsApplication.Controllers
{
    public class GroupNameController : Controller
    {
        private cmsEntities db = new cmsEntities();

        // GET: GroupName
        public ActionResult Index()
        {
            return View(db.group_name.ToList());
        }

        // GET: GroupName/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            group_name group_name = db.group_name.Find(id);
            if (group_name == null)
            {
                return HttpNotFound();
            }
            return View(group_name);
        }

        // GET: GroupName/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroupName/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "department_id,department_name")] group_name group_name)
        {
            if (ModelState.IsValid)
            {
                db.group_name.Add(group_name);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(group_name);
        }

        // GET: GroupName/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            group_name group_name = db.group_name.Find(id);
            if (group_name == null)
            {
                return HttpNotFound();
            }
            return View(group_name);
        }

        // POST: GroupName/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "department_id,department_name")] group_name group_name)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group_name).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group_name);
        }

        // GET: GroupName/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            group_name group_name = db.group_name.Find(id);
            if (group_name == null)
            {
                return HttpNotFound();
            }
            return View(group_name);
        }

        // POST: GroupName/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            group_name group_name = db.group_name.Find(id);
            db.group_name.Remove(group_name);
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
