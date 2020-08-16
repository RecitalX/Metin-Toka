namespace Kurumsal.Models.Sınıflar
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Admin")]
    public partial class Admin
    {
        public int AdminId { get; set; }

        [StringLength(250)]
        public string Eposta { get; set; }

        [StringLength(250)]
        public string Sifre { get; set; }

        [StringLength(50)]
        public string Yetki { get; set; }
    }
}