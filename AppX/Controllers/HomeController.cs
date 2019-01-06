using AppX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppX.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Employees", new { area = "" });
        }

        public ActionResult Addresses()
        {
            return RedirectToAction("Index", "Addresses", new { area = "" });
        }

        public ActionResult WorkLogs()
        {
            return RedirectToAction("Index", "WorkLogs", new { area = "" });
        }

        public ActionResult Departments()
        {
            return RedirectToAction("Index", "Departmentxes", new { area = "" });
        }

        public ActionResult AllTables()
        {
            var Query = (from ep in db.Employees
                        join e in db.Addresses on ep.Id equals e.Emp_id
                        join t in db.WorkLogs on e.Emp_id equals t.Emp_id
                        select new AllTables
                        {
                            Id = ep.Id,
                            Emp_name = ep.Emp_name,
                            Job_name = ep.Job_name,
                            Hire_date = ep.Hire_date,
                            Salary = ep.Salary,
                            Dep_name = ep.CurrentDepartment.Dep_name,
                            Dep_location = ep.CurrentDepartment.Dep_location,
                            Street = e.Street,
                            Zip = e.Zip,
                            City = e.City,
                            Wl_id = t.Wl_id,
                            Start_time = t.Start_time,
                            End_time = t.End_time,   
                        });

            return View(Query.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}