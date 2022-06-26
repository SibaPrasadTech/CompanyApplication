using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyApplication.ViewModels
{
    public class DepartmentEmployeeGroupViewModel
    {
        public string DeptName { get; set; }     

        public int DepartmentId { get; set; }
        public int? Age { get; set; }
        public int? Salary { get; set; }    
    }
}