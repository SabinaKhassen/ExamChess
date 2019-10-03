namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeChecker : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Checkers", "Movement", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Checkers", "Movement");
        }
    }
}
