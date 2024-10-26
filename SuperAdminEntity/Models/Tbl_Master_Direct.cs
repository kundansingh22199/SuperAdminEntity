namespace SuperAdminEntity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tbl_Master_Direct
    {
        public int id { get; set; }

        [StringLength(20)]
        public string Inc_type { get; set; }

        public decimal? Inc_per { get; set; }

        public decimal? Inc_fix { get; set; }

        public decimal? Inc_per_id { get; set; }

        public int? Inc_all_id { get; set; }

        public int? Inc_after_id { get; set; }

        public decimal? Package { get; set; }

        [StringLength(100)]
        public string Domain { get; set; }
    }
}
