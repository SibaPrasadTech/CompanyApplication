using CompanyApplication.Models;
using CompanyApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyApplication.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly CompanyDbContext context;
        // GET: Department

        public DepartmentController()
        {
            context = new CompanyDbContext();
        }
        public ActionResult Index()
        {
            /*SELECT[Departments].DepartmentId , 
                [Departments].DeptName, 
                COUNT([Employees].Salary) AS TOTALEMPLOYEES, 
                ISNULL(AVG([Employees].Salary),0) AS AVGSALARY
            FROM[CompanyDb].[dbo].[Departments] LEFT OUTER JOIN[CompanyDb].[dbo].[Employees]
            ON[Departments].DepartmentId = [Employees].DepartmentId
            GROUP BY[Departments].DeptName, [Departments].DepartmentId
            ORDER BY TOTALEMPLOYEES DESC;*/
            /*IList<DepartmentExtendedViewModel> resultEx =
                context.Departments
                .Join(context.Employees, d => d.DepartmentId, e => e.DepartmentId, (d, e) => new { e.Name, e.Salary, d.DeptName })
                .GroupBy(t => t.DeptName)
                .Select(g => new DepartmentExtendedViewModel { DepartmentName = g.Key, TotalNumberOfEmployees = g.Count(), AverageSalary = g.Average(x => x.Salary) }).ToList();*/

            /*IList<DepartmentExtendedViewModel> resultEx 
                = (
                    from e in context.Employees
                    join d in context.Departments
                    on e.DepartmentId equals d.DepartmentId
                    group e by d.DeptName into g
                    select new DepartmentExtendedViewModel { 
                                                                DepartmentName = g.Key, 
                                                                TotalNumberOfEmployees = g.Count(), 
                                                                AverageSalary = g.Average(x => x.Salary)
                                                           }).ToList();*/
            /*var departments = context.Departments.ToList();*/

            var departments = context.Departments.ToList();
            return View("Index", departments);
        }

        public ActionResult DepartmentExtended()
        {
            /*SELECT[Departments].DepartmentId , 
                [Departments].DeptName, 
                COUNT([Employees].Salary) AS TOTALEMPLOYEES, 
                ISNULL(AVG([Employees].Salary),0) AS AVGSALARY
            FROM[CompanyDb].[dbo].[Departments] LEFT OUTER JOIN[CompanyDb].[dbo].[Employees]
            ON[Departments].DepartmentId = [Employees].DepartmentId
            GROUP BY[Departments].DeptName, [Departments].DepartmentId
            ORDER BY TOTALEMPLOYEES DESC;*/
            /*IList<DepartmentExtendedViewModel> resultEx =
                context.Departments
                .Join(context.Employees, d => d.DepartmentId, e => e.DepartmentId, (d, e) => new { e.Name, e.Salary, d.DeptName })
                .GroupBy(t => t.DeptName)
                .Select(g => new DepartmentExtendedViewModel { DepartmentName = g.Key, TotalNumberOfEmployees = g.Count(), AverageSalary = g.Average(x => x.Salary) }).ToList();*/

            /*IList<DepartmentExtendedViewModel> resultEx 
                = (
                    from e in context.Employees
                    join d in context.Departments
                    on e.DepartmentId equals d.DepartmentId
                    group e by d.DeptName into g
                    select new DepartmentExtendedViewModel { 
                                                                DepartmentName = g.Key, 
                                                                TotalNumberOfEmployees = g.Count(), 
                                                                AverageSalary = g.Average(x => x.Salary)
                                                           }).ToList();*/
            /*var departments = context.Departments.ToList();*/
            IList<DepartmentExtendedViewModel> resultEx
                = (
                    from d in context.Departments
                    join e in context.Employees
                    on d.DepartmentId equals e.DepartmentId into ed
                    from eds in ed.DefaultIfEmpty()
                    group new DepartmentEmployeeGroupViewModel
                    {
                        DeptName = d.DeptName,
                        DepartmentId = d.DepartmentId,
                        Age = eds.Age,
                        Salary = eds.Salary
                    }
                    by d.DeptName into g
                    select new DepartmentExtendedViewModel
                    {
                        DepartmentName = g.Key,
                        TotalNumberOfEmployees = g.Count(x => x.Age != null),
                        AverageSalary = g.Average(x => x.Salary == null ? 0 : x.Salary)
                    }).ToList();
            /*var departments = context.Departments.ToList();*/
            return View("DepartmentExtended", resultEx);
        }

        public ActionResult AddDepartment()
        {
            Department department = new Department();
            return View("DepartmentForm", department);
        }

        [HttpPost]
        public ActionResult SaveDepartment(Department dept)
        {
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("Model State Invalid");
                return View("Index");
            }
            Debug.WriteLine("Dept Name : " + dept.DeptName);
            context.Departments.Add(dept);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}