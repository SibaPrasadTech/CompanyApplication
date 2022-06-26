using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyApplication.ViewModels
{
    public class DepartmentExtendedViewModel
    {
        public string DepartmentName { get; set; }

        public int TotalNumberOfEmployees { get; set; }
        public double? AverageSalary { get; set; }
    }
}