namespace Kurumsal.Models.Sınıflar
{
    using Kurumsal.Models.DB_Contect;
    using System.Data.Entity;

    public partial class KurumsalDB : DbContext
    {
        public KurumsalDB()
            : base("name=KurumsalDB")
        {
            Database.SetInitializer(new Initializer());
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Hakkimizda> Hakkimizda { get; set; }
        public virtual DbSet<Hizmet> Hizmet { get; set; }
        public virtual DbSet<HizmetKategori> HizmetKategori { get; set; }
        public virtual DbSet<Iletisim> Iletisim { get; set; }
        public virtual DbSet<Katalog> Katalog { get; set; }
        public virtual DbSet<KatalogKategori> KatalogKategori { get; set; }
        public virtual DbSet<Kimlik> Kimlik { get; set; }
        public virtual DbSet<Mesaj> Mesaj { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}