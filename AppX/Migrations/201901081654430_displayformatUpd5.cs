namespace AppX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class displayformatUpd5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkLogs", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkLogs", "Date");
        }
    }
}
