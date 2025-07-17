namespace GameSalesSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameSurname_property_added_to_User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "NameSurname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "NameSurname");
        }
    }
}
