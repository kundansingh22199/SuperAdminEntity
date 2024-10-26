namespace SuperAdminEntity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tbl_PackageMaster
    {
        public int id { get; set; }

        public decimal? Package { get; set; }

        public DateTime? createdate { get; set; }

        [StringLength(100)]
        public string Domain { get; set; }
    }
}
