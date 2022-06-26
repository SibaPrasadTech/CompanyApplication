namespace CompanyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeptTableDataInsert : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Departments(DeptName)Values('IT')");
            Sql("Insert into Departments(DeptName)Values('HR')");
            Sql("Insert into Departments(DeptName)Values('Talent Acquisition')");
            Sql("Insert into Departments(DeptName)Values('Training & Development')");
        }
        
        public override void Down()
        {
            Sql("TRUNCATE TABLE Departments");
        }
    }
}
