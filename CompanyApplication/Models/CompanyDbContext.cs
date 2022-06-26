using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CompanyApplication.Models
{
    public class CompanyDbContext: DbContext
    {
        public CompanyDbContext() : base("DifferentNameForConnString") { }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }


    }
}