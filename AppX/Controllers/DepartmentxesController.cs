using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppX.Models;

namespace AppX.Controllers
{
    public class DepartmentxesController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: Departmentxes
        public ActionResult Index()
        {
            return View(db.Departmentxes.ToList());
        }

        // GET: Departmentxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departmentx departmentx = db.Departmentxes.Find(id);
            if (departmentx == null)
            {
                return HttpNotFound();
            }
            return View(departmentx);
        }

        // GET: Departmentxes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departmentxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Dep_id,Dep_name,Dep_location")] Departmentx departmentx)
        {
            if (ModelState.IsValid)
            {
                db.Departmentxes.Add(departmentx);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departmentx);
        }

        // GET: Departmentxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departmentx departmentx = db.Departmentxes.Find(id);
            if (departmentx == null)
            {
                return HttpNotFound();
            }
            return View(departmentx);
        }

        // POST: Departmentxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Dep_id,Dep_name,Dep_location")] Departmentx departmentx)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departmentx).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departmentx);
        }

        // GET: Departmentxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departmentx departmentx = db.Departmentxes.Find(id);
            if (departmentx == null)
            {
                return HttpNotFound();
            }
            return View(departmentx);
        }

        // POST: Departmentxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departmentx departmentx = db.Departmentxes.Find(id);
            db.Departmentxes.Remove(departmentx);
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
