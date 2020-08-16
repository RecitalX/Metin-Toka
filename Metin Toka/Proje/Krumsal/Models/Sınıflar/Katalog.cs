namespace Kurumsal.Models.Sınıflar
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Katalog")]
    public partial class Katalog
    {
        public int Id { get; set; }

        public string ResimURL { get; set; }

        public int? KatalogId { get; set; }

        public virtual KatalogKategori KatalogKategori { get; set; }
    }
}