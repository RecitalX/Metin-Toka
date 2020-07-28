using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kurumsal.Models.Sınıflar
{
    [Table("Mesaj")]
    public class Mesaj
    {
        public int ID { get; set; }
        [StringLength(100)]
        [MaxLength(100, ErrorMessage ="Lütfen 100 karakterden daha az giriniz")]
        public string AdSoyad { get; set; }
        [StringLength(50)]
        [MaxLength(50,ErrorMessage ="Lütfen 50 karakterden daha az bilgi giriniz")]
        public string Telefon { get; set; }
        [StringLength(100)]
        [MaxLength(100,ErrorMessage ="Lütfen 100 karakterden daha az giriniz")]
        public string Konu { get; set; }
        public string İleti { get; set; }
        public int saat { get; set; }
    }
}