namespace SuperAdminEntity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ControlMst")]
    public class ControlMst
    {
        [StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        public int? pingeneration { get; set; }

        public int? changeprofile { get; set; }

        public int? payout { get; set; }

        public int? awards { get; set; }

        public int? reports { get; set; }

        public int? changepassword { get; set; }

        public int? activate { get; set; }

        public int? news { get; set; }

        public DateTime? date { get; set; }

        [Key]
        public int UserId { get; set; }
    }
}
