namespace Kurumsal.Models.Sınıflar
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

        public string Telefon { get; set; }

        public string Mail { get; set; }

        public string WeChat { get; set; }

        public string Whatsapp { get; set; }

        public string instagram { get; set; }

        public string Fax { get; set; }
    }
}
