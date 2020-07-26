using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kurumsal.Models.Sınıflar
{
    [Table("Hakkimizda")]
    public partial class Hakkimizda
    {
        public int HakkimizdaId { get; set; }
        [DisplayName("Açıklama")]
        public string Aciklama { get; set; }
    }
}