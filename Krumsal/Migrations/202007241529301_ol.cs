namespace Kurumsal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banner", "Url", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banner", "Url");
        }
    }
}
