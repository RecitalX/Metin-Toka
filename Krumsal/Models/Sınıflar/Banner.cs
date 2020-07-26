using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kurumsal.Models.Sınıflar
{
    [Table("Banner")]
    public class Banner
    {
        public int ID { get; set; }

        [StringLength(100)]
        [MaxLength(100, ErrorMessage = "100 Karakterden fazla girilemez")]
        public string Baslik { get; set; }

        [StringLength(100)]
        [MaxLength(100, ErrorMessage = "100 Karakterden fazla girilemez")]
        public string Aciklama { get; set; }
        public bool Onay { get; set; }
        public string Url { get; set; }

        [StringLength(500)]
        public string ResimURL { get; set; }
    }
}