namespace Kurumsal.Models.Sınıflar
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Mesaj")]
    public partial class Mesaj
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string AdSoyad { get; set; }

        [StringLength(50)]
        public string Telefon { get; set; }

        [StringLength(100)]
        public string Konu { get; set; }

        public string İleti { get; set; }

        public int saat { get; set; }
    }
}