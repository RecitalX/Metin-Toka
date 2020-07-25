namespace Kurumsal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HizmetKategori")]
    public partial class HizmetKategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HizmetKategori()
        {
            Hizmet = new HashSet<Hizmet>();
        }

        public int HizmetKategoriId { get; set; }

        [StringLength(100)]
        public string HizmetKategoriAdi { get; set; }

        [StringLength(250)]
        public string Aciklama { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hizmet> Hizmet { get; set; }
    }
}
