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
    public class WorkLogsController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();
        private readonly Models.Queries.QueryFactory m_QF;

        public WorkLogsController()
        {
            m_QF = new Models.Queries.QueryFactory();
        }

        // GET: WorkLogs
        public ActionResult Index(DateTime? dates = null, string searchString = null)
        {          
            var depLst = new List<DateTime>();

            var DepQuery = m_QF.WorkLogDates();

            depLst.AddRange(DepQuery.Distinct());
            ViewBag.dates = new SelectList(depLst);
            
            var workLogs = db.WorkLogs.Include(w => w.CurrentEmployee);

            if (!String.IsNullOrEmpty(searchString))
            {
                if (Int32.TryParse(searchString, out int id))
                {
                    workLogs = workLogs.Where(s => s.Emp_id.Equals(id));
                }
            }

            if (dates != null)
            {
                workLogs = workLogs.Where(x => x.Start_Date.Equals(dates.Value));
            }

            return View(workLogs.ToList());
        }

        // GET: WorkLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkLog workLog = db.WorkLogs.Find(id);
            if (workLog == null)
            {
                return HttpNotFound();
            }
            return View(workLog);
        }

        // GET: WorkLogs/Create
        public ActionResult Create()
        {
            ViewBag.Emp_id = new SelectList(db.Employees, "Id", "Emp_name");
            return View();
        }

        // POST: WorkLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Wl_id,Start_Date,Start_time,End_Date,End_time,Emp_id")] WorkLog workLog)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.WorkLogs.Add(workLog);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.exception = ex.Message;
                    return View("~/Views/ErrorHandler/Index.cshtml");
                }
            }

            ViewBag.Emp_id = new SelectList(db.Employees, "Id", "Emp_name", workLog.Emp_id);
            return View(workLog);
        }

        // GET: WorkLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkLog workLog = db.WorkLogs.Find(id);
            if (workLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.Emp_id = new SelectList(db.Employees, "Id", "Emp_name", workLog.Emp_id);
            return View(workLog);
        }

        // POST: WorkLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Wl_id,Start_Date,Start_time,End_Date,End_time,Emp_id")] WorkLog workLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Emp_id = new SelectList(db.Employees, "Id", "Emp_name", workLog.Emp_id);
            return View(workLog);
        }

        // GET: WorkLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkLog workLog = db.WorkLogs.Find(id);
            if (workLog == null)
            {
                return HttpNotFound();
            }
            return View(workLog);
        }

        // POST: WorkLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkLog workLog = db.WorkLogs.Find(id);
            db.WorkLogs.Remove(workLog);
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
