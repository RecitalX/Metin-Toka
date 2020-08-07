namespace Kurumsal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kimlik")]
    public partial class Kimlik
    {
        public int KimlikId { get; set; }

        public string Title { get; set; }

        public string Keywords { get; set; }

        public string Description { get; set; }

        public string LogoURL { get; set; }

        public string ResimURL { get; set; }
    }
}
