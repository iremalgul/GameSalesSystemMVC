namespace GameSalesSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class game_deneme_ekledim : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Deneme", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "Deneme");
        }
    }
}
