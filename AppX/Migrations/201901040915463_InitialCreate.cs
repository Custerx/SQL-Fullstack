namespace AppX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Emp_id = c.Int(nullable: false),
                        Street = c.String(nullable: false, maxLength: 40),
                        Zip = c.Int(nullable: false),
                        City = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.Emp_id)
                .ForeignKey("dbo.Employees", t => t.Emp_id)
                .Index(t => t.Emp_id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Emp_name = c.String(nullable: false, maxLength: 40),
                        Job_name = c.String(nullable: false, maxLength: 40),
                        Hire_date = c.DateTime(nullable: false),
                        Salary = c.Int(nullable: false),
                        Dep_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departmentxes", t => t.Dep_id, cascadeDelete: true)
                .Index(t => t.Dep_id);
            
            CreateTable(
                "dbo.Departmentxes",
                c => new
                    {
                        Dep_id = c.Int(nullable: false, identity: true),
                        Dep_name = c.String(nullable: false, maxLength: 40),
                        Dep_location = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.Dep_id);
            
            CreateTable(
                "dbo.WorkLogs",
                c => new
                    {
                        Wl_id = c.Int(nullable: false, identity: true),
                        Start_time = c.DateTime(nullable: false),
                        End_time = c.DateTime(nullable: false),
                        Emp_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Wl_id)
                .ForeignKey("dbo.Employees", t => t.Emp_id, cascadeDelete: true)
                .Index(t => t.Emp_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkLogs", "Emp_id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Dep_id", "dbo.Departmentxes");
            DropForeignKey("dbo.Addresses", "Emp_id", "dbo.Employees");
            DropIndex("dbo.WorkLogs", new[] { "Emp_id" });
            DropIndex("dbo.Employees", new[] { "Dep_id" });
            DropIndex("dbo.Addresses", new[] { "Emp_id" });
            DropTable("dbo.WorkLogs");
            DropTable("dbo.Departmentxes");
            DropTable("dbo.Employees");
            DropTable("dbo.Addresses");
        }
    }
}
