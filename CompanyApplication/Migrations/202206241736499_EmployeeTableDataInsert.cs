namespace CompanyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeTableDataInsert : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Employees(Name,Age,Salary,DepartmentId) Values('Ram',23,28000,1)");
            Sql("Insert into Employees(Name,Age,Salary,DepartmentId) Values('Shyam',26,37000,1)");
            Sql("Insert into Employees(Name,Age,Salary,DepartmentId) Values('Hari',29,55000,1)");
            Sql("Insert into Employees(Name,Age,Salary,DepartmentId) Values('Sita',31,40000,2)");
            Sql("Insert into Employees(Name,Age,Salary,DepartmentId) Values('Mita',22,18000,2)");
            Sql("Insert into Employees(Name,Age,Salary,DepartmentId) Values('Rita',27,25000,3)");
            Sql("Insert into Employees(Name,Age,Salary,DepartmentId) Values('Pramod',36,50000,4)");
        }
        
        public override void Down()
        {
            Sql("TRUNCATE TABLE Employees");
        }
    }
}
