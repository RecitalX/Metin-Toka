namespace Kurumsal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hakkimizda")]
    public partial class Hakkimizda
    {
        public int HakkimizdaId { get; set; }
        [DisplayName("Açıklama")]
        public string Aciklama { get; set; }
    }
}
