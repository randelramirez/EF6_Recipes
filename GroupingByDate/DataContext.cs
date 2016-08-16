using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupingByDate
{
    public class DataContext : DbContext
    {
        public DbSet<Registration> Registrations { get; set; }
    }
}
