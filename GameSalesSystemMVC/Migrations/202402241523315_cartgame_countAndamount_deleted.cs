namespace GameSalesSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartgame_countAndamount_deleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CartGames", "Count");
            DropColumn("dbo.CartGames", "GameAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartGames", "GameAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CartGames", "Count", c => c.Int(nullable: false));
        }
    }
}
