namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckerDeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Checkers", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.Checkers", "GameId", "dbo.Games");
            DropIndex("dbo.Checkers", new[] { "GameId" });
            DropIndex("dbo.Checkers", new[] { "ColorId" });
            AddColumn("dbo.Games", "WinnerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Games", "WinnerId");
            AddForeignKey("dbo.Games", "WinnerId", "dbo.Users", "Id", cascadeDelete: false);
            DropColumn("dbo.Games", "Deleted");
            DropTable("dbo.Checkers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Checkers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        Position = c.Int(nullable: false),
                        PrevPosition = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        IsQueen = c.Boolean(nullable: false),
                        IsEaten = c.Boolean(nullable: false),
                        Movement = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Games", "Deleted", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Games", "WinnerId", "dbo.Users");
            DropIndex("dbo.Games", new[] { "WinnerId" });
            DropColumn("dbo.Games", "WinnerId");
            CreateIndex("dbo.Checkers", "ColorId");
            CreateIndex("dbo.Checkers", "GameId");
            AddForeignKey("dbo.Checkers", "GameId", "dbo.Games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Checkers", "ColorId", "dbo.Colors", "Id", cascadeDelete: true);
        }
    }
}
