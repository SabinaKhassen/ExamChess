namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Blocked", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "Deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Deleted");
            DropColumn("dbo.Users", "Blocked");
        }
    }
}
