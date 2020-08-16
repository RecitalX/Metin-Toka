namespace Kurumsal.Models.Sınıflar
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Kimlik")]
    public partial class Kimlik
    {
        public int KimlikId { get; set; }

        public string Title { get; set; }

        public string Keywords { get; set; }

        public string Description { get; set; }

        public string LogoURL { get; set; }

        public string ResimURL { get; set; }
    }
}