
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kurumsal.Models.Sınıflar
{
    [Table("Katalog")]
    public class Katalog
    {
        [Key]
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string ResimURL { get; set; }
    }
}