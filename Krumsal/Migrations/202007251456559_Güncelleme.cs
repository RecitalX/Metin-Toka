namespace Kurumsal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Güncelleme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hakkimizda",
                c => new
                    {
                        HakkimizdaId = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.HakkimizdaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Hakkimizda");
        }
    }
}
