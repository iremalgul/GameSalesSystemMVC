namespace GameSalesSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        GameAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.CartId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(nullable: false),
                        PurchaseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PurchaseGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        GameAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.PurchaseId, cascadeDelete: true)
                .Index(t => t.PurchaseId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Genre = c.String(),
                        Description = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReviewDate = c.DateTime(nullable: false),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(),
                        UserId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "UserId", "dbo.Users");
            DropForeignKey("dbo.PurchaseGames", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.Reviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reviews", "GameId", "dbo.Games");
            DropForeignKey("dbo.PurchaseGames", "GameId", "dbo.Games");
            DropForeignKey("dbo.CartGames", "GameId", "dbo.Games");
            DropForeignKey("dbo.Carts", "Id", "dbo.Users");
            DropForeignKey("dbo.CartGames", "CartId", "dbo.Carts");
            DropIndex("dbo.Reviews", new[] { "GameId" });
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropIndex("dbo.PurchaseGames", new[] { "GameId" });
            DropIndex("dbo.PurchaseGames", new[] { "PurchaseId" });
            DropIndex("dbo.Purchases", new[] { "UserId" });
            DropIndex("dbo.Carts", new[] { "Id" });
            DropIndex("dbo.CartGames", new[] { "GameId" });
            DropIndex("dbo.CartGames", new[] { "CartId" });
            DropTable("dbo.Reviews");
            DropTable("dbo.Games");
            DropTable("dbo.PurchaseGames");
            DropTable("dbo.Purchases");
            DropTable("dbo.Users");
            DropTable("dbo.Carts");
            DropTable("dbo.CartGames");
        }
    }
}
