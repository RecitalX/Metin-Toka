namespace Kurumsal.Models.Sınıflar
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slider")]
    public partial class Slider
    {
        public int ID { get; set; }

        [StringLength(150)]
        public string Baslik { get; set; }

        [StringLength(300)]
        public string Aciklama { get; set; }

        [StringLength(500)]
        public string ResimURL { get; set; }
    }
}
