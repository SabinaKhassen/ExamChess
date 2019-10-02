namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BoardColors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColorOne = c.Int(nullable: false),
                        ColorTwo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colors", t => t.ColorOne, cascadeDelete: false)
                .ForeignKey("dbo.Colors", t => t.ColorTwo, cascadeDelete: false)
                .Index(t => t.ColorOne)
                .Index(t => t.ColorTwo);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerOne = c.Int(nullable: false),
                        PlayerTwo = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        ChessTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChessTypes", t => t.ChessTypeId)
                .ForeignKey("dbo.Users", t => t.PlayerOne)
                .ForeignKey("dbo.Users", t => t.PlayerTwo)
                .ForeignKey("dbo.BoardColors", t => t.ColorId)
                .Index(t => t.PlayerOne)
                .Index(t => t.PlayerTwo)
                .Index(t => t.ColorId)
                .Index(t => t.ChessTypeId);
            
            CreateTable(
                "dbo.ChessTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FIO = c.String(nullable: false, maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Nick = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 25),
                        CityId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.CityId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Checkers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    GameId = c.Int(nullable: false),
                    PositionX = c.Int(nullable: false),
                    PositionY = c.Int(nullable: false),
                    ColorId = c.Int(nullable: false),
                    CheckerTypeId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CheckerTypes", t => t.CheckerTypeId, cascadeDelete: false)
                .ForeignKey("dbo.Colors", t => t.ColorId, cascadeDelete: false)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: false)
                .Index(t => t.GameId)
                .Index(t => t.ColorId)
                .Index(t => t.CheckerTypeId);
            
            CreateTable(
                "dbo.CheckerTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CheckerType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Checkers", "GameId", "dbo.Games");
            DropForeignKey("dbo.Checkers", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.Checkers", "CheckerTypeId", "dbo.CheckerTypes");
            DropForeignKey("dbo.Games", "ColorId", "dbo.BoardColors");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Games", "PlayerTwo", "dbo.Users");
            DropForeignKey("dbo.Games", "PlayerOne", "dbo.Users");
            DropForeignKey("dbo.Users", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Games", "ChessTypeId", "dbo.ChessTypes");
            DropForeignKey("dbo.BoardColors", "ColorTwo", "dbo.Colors");
            DropForeignKey("dbo.BoardColors", "ColorOne", "dbo.Colors");
            DropIndex("dbo.Checkers", new[] { "CheckerTypeId" });
            DropIndex("dbo.Checkers", new[] { "ColorId" });
            DropIndex("dbo.Checkers", new[] { "GameId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Users", new[] { "CityId" });
            DropIndex("dbo.Games", new[] { "ChessTypeId" });
            DropIndex("dbo.Games", new[] { "ColorId" });
            DropIndex("dbo.Games", new[] { "PlayerTwo" });
            DropIndex("dbo.Games", new[] { "PlayerOne" });
            DropIndex("dbo.BoardColors", new[] { "ColorTwo" });
            DropIndex("dbo.BoardColors", new[] { "ColorOne" });
            DropTable("dbo.CheckerTypes");
            DropTable("dbo.Checkers");
            DropTable("dbo.Roles");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Users");
            DropTable("dbo.ChessTypes");
            DropTable("dbo.Games");
            DropTable("dbo.Colors");
            DropTable("dbo.BoardColors");
        }
    }
}
