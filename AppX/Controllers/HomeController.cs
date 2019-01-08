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
        private readonly Models.Queries.QueryFactory m_QF;

        public HomeController()
        {
            m_QF = new Models.Queries.QueryFactory();
        }

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

        public ActionResult AllTables(string department, string searchString)
        {
            var depLst = new List<string>();

            var DepQuery = m_QF.DepNames();

            depLst.AddRange(DepQuery.Distinct());
            ViewBag.department = new SelectList(depLst);

            var Query = m_QF.JoinAllTables();

            if (!String.IsNullOrEmpty(searchString))
            {
                Query = Query.Where(s => s.Emp_name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(department))
            {
                Query = Query.Where(x => x.Dep_name.Equals(department));
            }

            return View(Query.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}