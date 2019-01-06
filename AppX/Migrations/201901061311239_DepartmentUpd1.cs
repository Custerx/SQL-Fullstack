namespace AppX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentUpd1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Departmentxes", newName: "strings");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.strings", newName: "Departmentxes");
        }
    }
}
