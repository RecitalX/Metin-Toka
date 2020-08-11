namespace Kurumsal.Models.Sınıflar
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KatalogKategori")]
    public partial class KatalogKategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KatalogKategori()
        {
            Katalog = new HashSet<Katalog>();
        }

        [Key]
        public int KatalogId { get; set; }

        [StringLength(100)]
        public string Baslik { get; set; }

        [StringLength(250)]
        public string ResimURL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Katalog> Katalog { get; set; }
    }
}
