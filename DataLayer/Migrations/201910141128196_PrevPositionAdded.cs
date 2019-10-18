namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrevPositionAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Checkers", "PrevPosition", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Checkers", "PrevPosition");
        }
    }
}
