using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppX.Models.Queries
{
    public class QueryFactory
    {
        private EmployeeDBContext m_DB;
        private DepNames m_DP;
        private JoinAllTables m_JAT;

        public QueryFactory()
        {
            m_DB = new EmployeeDBContext();
            m_DP = new DepNames(m_DB);
            m_JAT = new JoinAllTables(m_DB);
        }

        public IEnumerable<string> DepNames()
        {
            return m_DP.Query();
        }

        public IEnumerable<AllTables> JoinAllTables()
        {
            return m_JAT.Query();
        }
    }
}