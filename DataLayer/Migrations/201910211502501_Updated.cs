namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Games", "ColorOneId", "dbo.Colors");
            //DropForeignKey("dbo.Games", "ColorTwoId", "dbo.Colors");
            //DropIndex("dbo.Games", new[] { "ColorOneId" });
            //DropIndex("dbo.Games", new[] { "ColorTwoId" });
            //CreateTable(
            //    "dbo.BoardColors",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            ColorOne = c.Int(nullable: false),
            //            ColorTwo = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Colors", t => t.ColorOne, cascadeDelete: true)
            //    .ForeignKey("dbo.Colors", t => t.ColorTwo, cascadeDelete: true)
            //    .Index(t => t.ColorOne)
            //    .Index(t => t.ColorTwo);
            
            //AddColumn("dbo.Games", "BoardColorId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Games", "BoardColorId");
            //AddForeignKey("dbo.Games", "BoardColorId", "dbo.BoardColors", "Id");
            //DropColumn("dbo.Games", "ColorOneId");
            //DropColumn("dbo.Games", "ColorTwoId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Games", "ColorTwoId", c => c.Int(nullable: false));
            //AddColumn("dbo.Games", "ColorOneId", c => c.Int(nullable: false));
            //DropForeignKey("dbo.Games", "BoardColorId", "dbo.BoardColors");
            //DropForeignKey("dbo.BoardColors", "ColorTwo", "dbo.Colors");
            //DropForeignKey("dbo.BoardColors", "ColorOne", "dbo.Colors");
            //DropIndex("dbo.Games", new[] { "BoardColorId" });
            //DropIndex("dbo.BoardColors", new[] { "ColorTwo" });
            //DropIndex("dbo.BoardColors", new[] { "ColorOne" });
            //DropColumn("dbo.Games", "BoardColorId");
            //DropTable("dbo.BoardColors");
            //CreateIndex("dbo.Games", "ColorTwoId");
            //CreateIndex("dbo.Games", "ColorOneId");
            //AddForeignKey("dbo.Games", "ColorTwoId", "dbo.Colors", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.Games", "ColorOneId", "dbo.Colors", "Id", cascadeDelete: true);
        }
    }
}
