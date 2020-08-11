namespace Kurumsal.Models.Sınıflar
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Katalog")]
    public partial class Katalog
    {
        public int Id { get; set; }

        public string ResimURL { get; set; }

        public int? KatalogId { get; set; }

        public virtual KatalogKategori KatalogKategori { get; set; }
    }
}
