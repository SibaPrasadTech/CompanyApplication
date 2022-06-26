using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyApplication.Models
{
    //https://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx
    
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DeptName { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}