namespace SuperAdminEntity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Tbl_Master_Binary
    {
        public int id { get; set; }

        [StringLength(20)]
        public string Inc_type { get; set; }

        public decimal? Inc_per { get; set; }

        public decimal? Inc_fix { get; set; }

        public decimal? Inc_per_id { get; set; }

        public decimal? Inc_capping { get; set; }

        [StringLength(20)]
        public string Ratio { get; set; }

        [StringLength(100)]
        public string CappingType { get; set; }

        public decimal? Package { get; set; }

        [StringLength(100)]
        public string Domain { get; set; }
    }
}
