namespace SuperAdminEntity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tbl_Master_Roi
    {
        public int id { get; set; }

        [StringLength(20)]
        public string roi_type { get; set; }

        public decimal? roi_fix { get; set; }

        public decimal? roi_per { get; set; }

        public decimal? roi_upto { get; set; }

        [StringLength(30)]
        public string inc_recuring { get; set; }

        [StringLength(100)]
        public string RoiDay { get; set; }

        public bool? sundayoff { get; set; }

        public bool? sunday_saturday_off { get; set; }

        public bool? random { get; set; }

        public decimal? min_per { get; set; }

        public decimal? max_per { get; set; }

        public decimal? Package { get; set; }

        [StringLength(100)]
        public string Domain { get; set; }
    }
}
