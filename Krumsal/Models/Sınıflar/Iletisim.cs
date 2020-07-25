namespace Kurumsal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Iletisim")]
    public partial class Iletisim
    {
        public int IletisimId { get; set; }

        [StringLength(250)]
        public string Telefon { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }

        [StringLength(50)]
        public string WeChat { get; set; }

        [StringLength(50)]
        public string Whatsapp { get; set; }

        [StringLength(50)]
        public string instagram { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }
    }
}
