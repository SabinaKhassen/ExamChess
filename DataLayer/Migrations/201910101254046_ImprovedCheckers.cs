namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImprovedCheckers : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Games", name: "ColorId", newName: "BoardColorId");
            RenameIndex(table: "dbo.Games", name: "IX_ColorId", newName: "IX_BoardColorId");
            AddColumn("dbo.Checkers", "Position", c => c.Int(nullable: false));
            DropColumn("dbo.Checkers", "PositionX");
            DropColumn("dbo.Checkers", "PositionY");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Checkers", "PositionY", c => c.Int(nullable: false));
            AddColumn("dbo.Checkers", "PositionX", c => c.Int(nullable: false));
            DropColumn("dbo.Checkers", "Position");
            RenameIndex(table: "dbo.Games", name: "IX_BoardColorId", newName: "IX_ColorId");
            RenameColumn(table: "dbo.Games", name: "BoardColorId", newName: "ColorId");
        }
    }
}
