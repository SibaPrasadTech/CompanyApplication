using CompanyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyApplication.ViewModels
{
    public class EmployeeViewModel
    {
        public IEnumerable<Department> Department { get; set; }
        public Employee Employee { get; set; }
    }
}