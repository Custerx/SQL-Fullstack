using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppX.Models.Queries
{
    public class SelectWorkLogDates
    {
        private EmployeeDBContext db;

        public SelectWorkLogDates(EmployeeDBContext a_edb)
        {
            db = a_edb;
        }

        public IEnumerable<DateTime> Query()
        {
            return from d in db.WorkLogs
                   where d.Start_Date != null
                   orderby d.Start_Date
                   select d.Start_Date;
        }
    }
}