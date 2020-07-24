namespace Kurumsal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hizmet")]
    public partial class Hizmet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hizmet()
        {
            Renk = new HashSet<Renk>();
        }

        public int HizmetId { get; set; }

        [StringLength(200)]
        public string Baslik { get; set; }

        public string Icerik { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        [StringLength(250)]
        public string ResimURL { get; set; }

        public int? HizmetKategoriId { get; set; }

        [StringLength(50)]
        public string UrunKodu { get; set; }

        public int? RenkId { get; set; }

        public virtual HizmetKategori HizmetKategori { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Renk> Renk { get; set; }
    }
}
