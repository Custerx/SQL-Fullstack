namespace AppX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class displayformatUpd7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkLogs", "Start_Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.WorkLogs", "End_Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.WorkLogs", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkLogs", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.WorkLogs", "End_Date");
            DropColumn("dbo.WorkLogs", "Start_Date");
        }
    }
}
