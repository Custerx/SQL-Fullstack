using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppX.Models.Queries
{
    public class DepNames
    {
        private EmployeeDBContext db;

        public DepNames(EmployeeDBContext a_edb)
        {
            db = a_edb;
        }

        public IEnumerable<string> Query()
        {
            return from d in db.Departmentxes
                    orderby d.Dep_name
                    select d.Dep_name;
        }
    }
}