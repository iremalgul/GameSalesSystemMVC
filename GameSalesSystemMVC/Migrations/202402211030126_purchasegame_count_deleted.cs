namespace GameSalesSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class purchasegame_count_deleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PurchaseGames", "Count");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseGames", "Count", c => c.Int(nullable: false));
        }
    }
}
