﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppX.Models;
using Microsoft.Extensions.Logging;

namespace AppX.Controllers
{
    public class AddressesController : Controller
    {
        private EmployeeDBContext db;
        private readonly Models.Queries.QueryFactory m_QF;

        // https://docs.microsoft.com/en-us/aspnet/web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/aspnet-error-handling
        protected override void OnException(ExceptionContext filterContext)
        {
            LoggerFactory loggerFactory = new LoggerFactory();
            ILogger logger = loggerFactory.CreateLogger("LogErrorAddress");

            filterContext.ExceptionHandled = true;

            //Log the error!!
            logger.LogError(filterContext.Exception.ToString());

            //Redirect
            filterContext.Result = RedirectToAction("Index", "ErrorHandler");
        }

        public AddressesController()
        {
            m_QF = new Models.Queries.QueryFactory();
            db = new EmployeeDBContext();
        }

        // GET: Addresses
        public ActionResult Index(string department, string searchString)
        {
            var depLst = new List<string>();

            var DepQuery = m_QF.DepNames();

            depLst.AddRange(DepQuery.Distinct());
            ViewBag.department = new SelectList(depLst);

            var addresses = db.Addresses.Include(a => a.Employee);

            if (!String.IsNullOrEmpty(searchString))
            {
                addresses = addresses.Where(s => s.Employee.Emp_name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(department))
            {
                addresses = addresses.Where(x => x.Employee.CurrentDepartment.Dep_name.Equals(department));
            }
            
            return View(addresses.ToList());
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            ViewBag.Emp_id = new SelectList(db.Employees, "Id", "Emp_name");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Emp_id,Street,Zip,City")] Address address)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Addresses.Add(address);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.exception = ex.Message;
                    return View("~/Views/ErrorHandler/Index.cshtml");
                }
            }

            ViewBag.Emp_id = new SelectList(db.Employees, "Id", "Emp_name", address.Emp_id);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.Emp_id = new SelectList(db.Employees, "Id", "Emp_name", address.Emp_id);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Emp_id,Street,Zip,City")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Emp_id = new SelectList(db.Employees, "Id", "Emp_name", address.Emp_id);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
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
