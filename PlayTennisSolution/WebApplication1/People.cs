namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class People
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Introduce { get; set; }

        public int? Sort { get; set; }

        public byte? Status { get; set; }

        public DateTime? Time { get; set; }

        public int? User { get; set; }
    }
}
