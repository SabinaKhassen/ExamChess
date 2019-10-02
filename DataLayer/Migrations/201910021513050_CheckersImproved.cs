namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckersImproved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Checkers", "CheckerTypeId", "dbo.CheckerTypes");
            DropForeignKey("dbo.Games", "ChessTypeId", "dbo.ChessTypes");
            DropIndex("dbo.Checkers", new[] { "CheckerTypeId" });
            AddColumn("dbo.Checkers", "IsQueen", c => c.Boolean(nullable: false));
            AddColumn("dbo.Checkers", "IsEaten", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ChessTypes", "Name", c => c.String());
            AddForeignKey("dbo.Games", "ChessTypeId", "dbo.ChessTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Checkers", "CheckerTypeId");
            DropTable("dbo.CheckerTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CheckerTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CheckerType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Checkers", "CheckerTypeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Games", "ChessTypeId", "dbo.ChessTypes");
            AlterColumn("dbo.ChessTypes", "Name", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Checkers", "IsEaten");
            DropColumn("dbo.Checkers", "IsQueen");
            CreateIndex("dbo.Checkers", "CheckerTypeId");
            AddForeignKey("dbo.Games", "ChessTypeId", "dbo.ChessTypes", "Id");
            AddForeignKey("dbo.Checkers", "CheckerTypeId", "dbo.CheckerTypes", "Id", cascadeDelete: true);
        }
    }
}
