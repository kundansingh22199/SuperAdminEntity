namespace SuperAdminEntity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tbl_UserPrefix
    {
        public int id { get; set; }

        [StringLength(100)]
        public string Domain { get; set; }

        [StringLength(10)]
        public string RegPrefix { get; set; }

        public int? TotalDigit { get; set; }
    }
}
