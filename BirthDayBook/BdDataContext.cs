using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace BirthDayBook
{
    public class BdDataContext : DataContext
    {
        public BdDataContext(string connectionString)
            : base(connectionString)
        {
        }
        public Table<DbClass> Member
        {
            get
            {
                return this.GetTable<DbClass>();
            }
        }
    }
}
