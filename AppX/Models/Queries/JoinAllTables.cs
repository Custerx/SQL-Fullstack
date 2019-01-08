using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppX.Models.Queries
{
    public class JoinAllTables
    {
        private EmployeeDBContext db;

        public JoinAllTables(EmployeeDBContext a_edb)
        {
            db = a_edb;
        }

        public IEnumerable<AllTables> Query()
        {
            return (from ep in db.Employees
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
        }
    }
}