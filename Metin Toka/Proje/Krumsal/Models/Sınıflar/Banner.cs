namespace Kurumsal.Models.Sınıflar
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Banner")]
    public partial class Banner
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Baslik { get; set; }

        [StringLength(100)]
        public string Aciklama { get; set; }

        public bool Onay { get; set; }

        public string Url { get; set; }

        [StringLength(500)]
        public string ResimURL { get; set; }
    }
}