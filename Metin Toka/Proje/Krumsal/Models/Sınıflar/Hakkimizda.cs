namespace Kurumsal.Models.Sınıflar
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Hakkimizda")]
    public partial class Hakkimizda
    {
        public int HakkimizdaId { get; set; }

        public string Aciklama { get; set; }
    }
}