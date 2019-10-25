namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedGame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "Deleted");
        }
    }
}
