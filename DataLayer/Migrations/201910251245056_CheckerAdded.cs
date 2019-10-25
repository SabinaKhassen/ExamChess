//namespace DataLayer.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;

//    public partial class CheckerAdded : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.Checkers",
//                c => new
//                {
//                    Id = c.Int(nullable: false, identity: true),
//                    GameId = c.Int(nullable: false),
//                    Position = c.Int(nullable: false),
//                    ColorId = c.Int(nullable: false),
//                })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Colors", t => t.ColorId, cascadeDelete: false)
//                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: false)
//                .Index(t => t.GameId)
//                .Index(t => t.ColorId);

//        }

//        public override void Down()
//        {
//            DropForeignKey("dbo.Checkers", "GameId", "dbo.Games");
//            DropForeignKey("dbo.Checkers", "ColorId", "dbo.Colors");
//            DropIndex("dbo.Checkers", new[] { "ColorId" });
//            DropIndex("dbo.Checkers", new[] { "GameId" });
//            DropTable("dbo.Checkers");
//        }
//    }
//}
