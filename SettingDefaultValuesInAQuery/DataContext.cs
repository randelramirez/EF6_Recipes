﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingDefaultValuesInAQuery
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}
