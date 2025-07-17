namespace GameSalesSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class game_deneme_sildim : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Games", "Deneme");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "Deneme", c => c.String());
        }
    }
}
