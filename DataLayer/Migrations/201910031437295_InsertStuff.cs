namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertStuff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Checkers", "Movement", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Checkers", "Movement", c => c.DateTime(nullable: false));
        }
    }
}
