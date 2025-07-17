namespace GameSalesSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class picture_property_added_to_game : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "Picture");
        }
    }
}
