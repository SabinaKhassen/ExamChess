namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeGame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "BeginGame", c => c.DateTime(nullable: false));
            AddColumn("dbo.Games", "EndGame", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "EndGame");
            DropColumn("dbo.Games", "BeginGame");
        }
    }
}
