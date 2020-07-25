namespace Kurumsal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Eposta = c.String(maxLength: 250),
                        Sifre = c.String(maxLength: 250),
                        Yetki = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Hizmet",
                c => new
                    {
                        HizmetId = c.Int(nullable: false, identity: true),
                        Baslik = c.String(maxLength: 200),
                        Icerik = c.String(),
                        Aciklama = c.String(maxLength: 500),
                        ResimURL = c.String(maxLength: 250),
                        HizmetKategoriId = c.Int(),
                        UrunKodu = c.String(maxLength: 50),
                        RenkId = c.Int(),
                    })
                .PrimaryKey(t => t.HizmetId)
                .ForeignKey("dbo.HizmetKategori", t => t.HizmetKategoriId)
                .Index(t => t.HizmetKategoriId);
            
            CreateTable(
                "dbo.HizmetKategori",
                c => new
                    {
                        HizmetKategoriId = c.Int(nullable: false, identity: true),
                        HizmetKategoriAdi = c.String(maxLength: 100),
                        Aciklama = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.HizmetKategoriId);
            
            CreateTable(
                "dbo.Renk",
                c => new
                    {
                        RenkId = c.Int(nullable: false, identity: true),
                        RenkAdi = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.RenkId);
            
            CreateTable(
                "dbo.Iletisim",
                c => new
                    {
                        IletisimId = c.Int(nullable: false, identity: true),
                        Telefon = c.String(maxLength: 250),
                        Mail = c.String(maxLength: 50),
                        WeChat = c.String(maxLength: 50),
                        Whatsapp = c.String(maxLength: 50),
                        instagram = c.String(maxLength: 50),
                        Fax = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IletisimId);
            
            CreateTable(
                "dbo.Kimlik",
                c => new
                    {
                        KimlikId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Keywords = c.String(),
                        Description = c.String(),
                        LogoURL = c.String(),
                        ResimURL = c.String(),
                    })
                .PrimaryKey(t => t.KimlikId);
            
            CreateTable(
                "dbo.Slider",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(maxLength: 100),
                        Aciklama = c.String(maxLength: 100),
                        ResimURL = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RenkHizmet",
                c => new
                    {
                        HizmetId = c.Int(nullable: false),
                        RenkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HizmetId, t.RenkId })
                .ForeignKey("dbo.Hizmet", t => t.HizmetId, cascadeDelete: true)
                .ForeignKey("dbo.Renk", t => t.RenkId, cascadeDelete: true)
                .Index(t => t.HizmetId)
                .Index(t => t.RenkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RenkHizmet", "RenkId", "dbo.Renk");
            DropForeignKey("dbo.RenkHizmet", "HizmetId", "dbo.Hizmet");
            DropForeignKey("dbo.Hizmet", "HizmetKategoriId", "dbo.HizmetKategori");
            DropIndex("dbo.RenkHizmet", new[] { "RenkId" });
            DropIndex("dbo.RenkHizmet", new[] { "HizmetId" });
            DropIndex("dbo.Hizmet", new[] { "HizmetKategoriId" });
            DropTable("dbo.RenkHizmet");
            DropTable("dbo.Slider");
            DropTable("dbo.Kimlik");
            DropTable("dbo.Iletisim");
            DropTable("dbo.Renk");
            DropTable("dbo.HizmetKategori");
            DropTable("dbo.Hizmet");
            DropTable("dbo.Admin");
        }
    }
}
