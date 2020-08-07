using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kurumsal.Models.Sınıflar
{
    [Table("Slider")]
    public partial class Slider
    {
        public int ID { get; set; }

        [StringLength(150)]
        [MaxLength(150, ErrorMessage = "150 Karakterden fazla girilemez")]
        public string Baslik { get; set; }

        [StringLength(300)]
        [MaxLength(300, ErrorMessage = "300 Karakterden fazla girilemez")]
        public string Aciklama { get; set; }

        [StringLength(500)]
        public string ResimURL { get; set; }
    }
}