using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchingObjectsWithNativeSQLStatements
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
