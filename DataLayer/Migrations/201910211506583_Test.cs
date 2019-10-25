namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BoardColors", "ColorOne", "dbo.Colors");
            DropForeignKey("dbo.BoardColors", "ColorTwo", "dbo.Colors");
            DropForeignKey("dbo.Games", "ColorId", "dbo.BoardColors");
            DropForeignKey("dbo.Games", "BoardColorId", "dbo.BoardColors");
            DropIndex("dbo.BoardColors", new[] { "ColorOne" });
            DropIndex("dbo.BoardColors", new[] { "ColorTwo" });
            DropIndex("dbo.Games", new[] { "BoardColorId" });
            AddColumn("dbo.Games", "ColorOneId", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "ColorTwoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Games", "ColorOneId");
            CreateIndex("dbo.Games", "ColorTwoId");
            AddForeignKey("dbo.Games", "ColorOneId", "dbo.Colors", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Games", "ColorTwoId", "dbo.Colors", "Id", cascadeDelete: false);
            DropColumn("dbo.Games", "BoardColorId");
            DropTable("dbo.BoardColors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BoardColors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColorOne = c.Int(nullable: false),
                        ColorTwo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Games", "BoardColorId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Games", "ColorTwoId", "dbo.Colors");
            DropForeignKey("dbo.Games", "ColorOneId", "dbo.Colors");
            DropIndex("dbo.Games", new[] { "ColorTwoId" });
            DropIndex("dbo.Games", new[] { "ColorOneId" });
            DropColumn("dbo.Games", "ColorTwoId");
            DropColumn("dbo.Games", "ColorOneId");
            CreateIndex("dbo.Games", "BoardColorId");
            CreateIndex("dbo.BoardColors", "ColorTwo");
            CreateIndex("dbo.BoardColors", "ColorOne");
            AddForeignKey("dbo.Games", "BoardColorId", "dbo.BoardColors", "Id");
            AddForeignKey("dbo.BoardColors", "ColorTwo", "dbo.Colors", "Id", cascadeDelete: false);
            AddForeignKey("dbo.BoardColors", "ColorOne", "dbo.Colors", "Id", cascadeDelete: false);
        }
    }
}
