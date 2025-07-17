namespace GameSalesSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class all_string_nvarchar_max : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Username", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Users", "Country", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Users", "NameSurname", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Games", "Title", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Games", "Genre", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Games", "Description", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Games", "Picture", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Reviews", "Comment", c => c.String(maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "Comment", c => c.String());
            AlterColumn("dbo.Games", "Picture", c => c.String());
            AlterColumn("dbo.Games", "Description", c => c.String());
            AlterColumn("dbo.Games", "Genre", c => c.String());
            AlterColumn("dbo.Games", "Title", c => c.String());
            AlterColumn("dbo.Users", "NameSurname", c => c.String());
            AlterColumn("dbo.Users", "Country", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
        }
    }
}
