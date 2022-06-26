using CompanyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CompanyApplication.ViewModels;
using System.Diagnostics;

namespace CompanyApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CompanyDbContext context;

        public EmployeeController()
        {
            context = new CompanyDbContext();
        }
        // GET: Employee
        public ActionResult Index()
        {
            var context = new CompanyDbContext();
            var employeeList = this.context.Employees.Include(em => em.Department).ToList();
            /*Employee emp = this.context.Employees.Include( em => em.Department).ToList();*/
            return View("Index",employeeList);
        }

        public ActionResult AddEmployee()
        {
            var employeeViewModel = new EmployeeViewModel()
            {
                Department = context.Departments.ToList(),
                Employee = new Employee()
            };

            return View("EmployeeForm", employeeViewModel);
        }

        public ActionResult EditEmployee(int id)
        {
            var employeeFromDatabase = context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            var employeeViewModel = new EmployeeViewModel()
            {
                Department = context.Departments.ToList(),
                Employee = employeeFromDatabase
            };
            
            return View("EmployeeForm", employeeViewModel);
        }

        [HttpPost]
        public ActionResult SaveEmployee(EmployeeViewModel empModel)
        {
            if (! ModelState.IsValid)
            {
                if(empModel.Employee.EmployeeId == 0)
                    return RedirectToAction("AddEmployee", "Employee");
                else
                    return RedirectToAction("EditEmployee", "Employee");
            }

            if (empModel.Employee.EmployeeId == 0)
            {
                /*Debug.WriteLine("Emp Name : " + empModel.Employee.Name);
                Debug.WriteLine("Emp Age : " + empModel.Employee.Age);
                Debug.WriteLine("Emp Salary : " + empModel.Employee.Salary);*/
                context.Employees.Add(empModel.Employee);
            }
            else
            {
                Debug.Write("Dept ID : " + empModel.Employee.DepartmentId);
                var employeeFromDb = context.Employees.FirstOrDefault(x => x.EmployeeId == empModel.Employee.EmployeeId);
                employeeFromDb.Name = empModel.Employee.Name;
                employeeFromDb.Age = empModel.Employee.Age;
                employeeFromDb.Salary = empModel.Employee.Salary;
                employeeFromDb.DepartmentId = empModel.Employee.DepartmentId;
            }

            context.SaveChanges();
            /*return View("Index");*/
            return RedirectToAction("Index", "Employee");
        }

    }
}