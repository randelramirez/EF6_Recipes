﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingAQueryResultToAModel
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
